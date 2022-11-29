using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.StoreService;

[DependsOn(
    typeof(StoreServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class StoreServiceApplicationContractsModule : AbpModule
{

}
