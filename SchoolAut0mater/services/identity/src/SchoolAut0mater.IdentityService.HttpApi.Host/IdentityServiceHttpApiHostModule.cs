using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Authentication.Twitter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolAut0mater.IdentityService.DbMigrations;
using SchoolAut0mater.IdentityService.EntityFrameworkCore;
using SchoolAut0mater.Shared.Hosting.AspNetCore;
using SchoolAut0mater.Shared.Hosting.Microservices;
using Prometheus;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.IdentityService;

[DependsOn(
    typeof(SchoolAut0materSharedHostingMicroservicesModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationModule),
    typeof(IdentityServiceHttpApiModule)
)]
public class IdentityServiceHttpApiHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // Enable if you need these
        // var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        JwtBearerConfigurationHelper.Configure(context, "IdentityService");
        SwaggerConfigurationHelper.ConfigureWithAuth(
            context: context,
            authority: configuration["AuthServer:Authority"],
            scopes: new
                Dictionary<string, string> /* Requested scopes for authorization code request and descriptions for swagger UI only */
                {
                    {"IdentityService", "Identity Service API"}
                },
            apiTitle: "Identity Service API"
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

        ConfigureExternalProviders(context);
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
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity Service API");
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
                .GetRequiredService<IdentityServiceDatabaseMigrationChecker>()
                .CheckAndApplyDatabaseMigrationsAsync();
        }
    }

    private void ConfigureExternalProviders(ServiceConfigurationContext context)
    {
        context.Services
        .AddDynamicExternalLoginProviderOptions<GoogleOptions>(
            GoogleDefaults.AuthenticationScheme,
            options =>
            {
                options.WithProperty(x => x.ClientId);
                options.WithProperty(x => x.ClientSecret, isSecret: true);
            }
        )
        .AddDynamicExternalLoginProviderOptions<MicrosoftAccountOptions>(
            MicrosoftAccountDefaults.AuthenticationScheme,
            options =>
            {
                options.WithProperty(x => x.ClientId);
                options.WithProperty(x => x.ClientSecret, isSecret: true);
            }
        )
        .AddDynamicExternalLoginProviderOptions<TwitterOptions>(
            TwitterDefaults.AuthenticationScheme,
            options =>
            {
                options.WithProperty(x => x.ConsumerKey);
                options.WithProperty(x => x.ConsumerSecret, isSecret: true);
            }
        );
    }
}
