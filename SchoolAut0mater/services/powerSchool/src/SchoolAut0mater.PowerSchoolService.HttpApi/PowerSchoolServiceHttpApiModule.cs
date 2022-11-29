using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using SchoolAut0mater.PowerSchoolService.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.PowerSchoolService;

[DependsOn(
    typeof(PowerSchoolServiceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class PowerSchoolServiceHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(PowerSchoolServiceHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<PowerSchoolServiceResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
