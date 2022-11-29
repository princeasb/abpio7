using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolAut0mater.AdministrationService.DbMigrations;
using SchoolAut0mater.AdministrationService.EntityFrameworkCore;
using SchoolAut0mater.Shared.Hosting.AspNetCore;
using SchoolAut0mater.Shared.Hosting.Microservices;
using Prometheus;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Http.Client.IdentityModel.Web;
using Volo.Abp.Identity;
using Volo.Abp.LanguageManagement.External;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace SchoolAut0mater.AdministrationService;

[DependsOn(
    typeof(SchoolAut0materSharedLocalizationModule),
    typeof(AbpHttpClientIdentityModelWebModule),
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
    typeof(AbpIdentityHttpApiClientModule),
    typeof(AbpAccountAdminApplicationContractsModule),
    typeof(AbpAccountPublicApplicationContractsModule),
    typeof(SchoolAut0materSharedHostingMicroservicesModule),
    typeof(AdministrationServiceApplicationModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceHttpApiModule)
)]
public class AdministrationServiceHttpApiHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // Enable if you need these
        // var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        JwtBearerConfigurationHelper.Configure(context, "AdministrationService");
        SwaggerConfigurationHelper.ConfigureWithAuth(
            context: context,
            authority: configuration["AuthServer:Authority"],
            scopes: new
                Dictionary<string, string> /* Requested scopes for authorization code request and descriptions for swagger UI only */
                {
                    {"AdministrationService", "Administration Service API"}
                },
            apiTitle: "Administration Service API"
        );
        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(
                        configuration["App:CorsOrigins"]
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.Trim().RemovePostFix("/"))
                            .ToArray()
                    )
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
        
        Configure<PermissionManagementOptions>(options =>
        {
            options.IsDynamicPermissionStoreEnabled = true;
        });
        
        Configure<FeatureManagementOptions>(options =>
        {
            options.IsDynamicFeatureStoreEnabled = true;
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCorrelationId();
        app.UseAbpRequestLocalization();
        app.UseAbpSecurityHeaders();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
        app.UseHttpMetrics();
        app.UseAuthentication();
        app.UseAbpClaimsMap();
        app.UseMultiTenancy();
        app.UseAuthorization();
        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Administration Service API");
            options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
        });
        app.UseAbpSerilogEnrichers();
        app.UseAuditing();
        app.UseUnitOfWork();
        app.UseConfiguredEndpoints(endpoints =>
        {
            endpoints.MapMetrics();
        });
    }

    public async override Task OnPostApplicationInitializationAsync(ApplicationInitializationContext context)
    {
        using (var scope = context.ServiceProvider.CreateScope())
        {
            await scope.ServiceProvider
                .GetRequiredService<AdministrationServiceDatabaseMigrationChecker>()
                .CheckAndApplyDatabaseMigrationsAsync();
        }
    }
}
