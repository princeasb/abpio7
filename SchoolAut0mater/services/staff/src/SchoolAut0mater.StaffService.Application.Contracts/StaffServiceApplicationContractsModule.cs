using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.StaffService;

[DependsOn(
    typeof(StaffServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class StaffServiceApplicationContractsModule : AbpModule
{

}
