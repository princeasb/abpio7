using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using SchoolAut0mater.StaffService.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.StaffService;

[DependsOn(
    typeof(StaffServiceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class StaffServiceHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(StaffServiceHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<StaffServiceResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
