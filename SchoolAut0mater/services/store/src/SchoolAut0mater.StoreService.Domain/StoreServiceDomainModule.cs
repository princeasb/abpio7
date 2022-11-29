using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.StoreService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(StoreServiceDomainSharedModule)
)]
public class StoreServiceDomainModule : AbpModule
{
}
