using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using SchoolAut0mater.CoreService.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.CoreService;

[DependsOn(
    typeof(CoreServiceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class CoreServiceHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(CoreServiceHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<CoreServiceResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
