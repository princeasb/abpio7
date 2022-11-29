using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using SchoolAut0mater.StoreService.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.StoreService;

[DependsOn(
    typeof(StoreServiceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class StoreServiceHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(StoreServiceHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<StoreServiceResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
