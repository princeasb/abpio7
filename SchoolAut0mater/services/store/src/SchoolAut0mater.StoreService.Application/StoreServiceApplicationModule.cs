using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.StoreService;

[DependsOn(
    typeof(StoreServiceDomainModule),
    typeof(StoreServiceApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class StoreServiceApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<StoreServiceApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<StoreServiceApplicationModule>(validate: true);
        });
    }
}
