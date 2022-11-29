using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.CoreService;

[DependsOn(
    typeof(CoreServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
)]
public class CoreServiceApplicationContractsModule : AbpModule
{

}
