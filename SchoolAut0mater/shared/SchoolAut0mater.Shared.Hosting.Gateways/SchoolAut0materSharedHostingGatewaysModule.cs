using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolAut0mater.Shared.Hosting.AspNetCore;
using Ocelot.DependencyInjection;
using Ocelot.Provider.Polly;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

namespace SchoolAut0mater.Shared.Hosting.Gateways;

[DependsOn(
    typeof(SchoolAut0materSharedHostingAspNetCoreModule),    
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
    typeof(AbpSwashbuckleModule)
)]
public class SchoolAut0materSharedHostingGatewaysModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var env = context.Services.GetHostingEnvironment();

        var ocelotBuilder = context.Services.AddOcelot(configuration)
            .AddPolly();

        if (!env.IsProduction())
        {
            ocelotBuilder.AddDelegatingHandler<AbpRemoveCsrfCookieHandler>(true);
        }
    }
}
