using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.PowerSchoolService;

[DependsOn(
    typeof(PowerSchoolServiceDomainModule),
    typeof(PowerSchoolServiceApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class PowerSchoolServiceApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<PowerSchoolServiceApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<PowerSchoolServiceApplicationModule>(validate: true);
        });
    }
}
