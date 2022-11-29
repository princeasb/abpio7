using Volo.Abp.Modularity;

namespace SchoolAut0mater.StoreService;

[DependsOn(
    typeof(StoreServiceApplicationModule),
    typeof(StoreServiceDomainTestModule)
    )]
public class StoreServiceApplicationTestModule : AbpModule
{

}
