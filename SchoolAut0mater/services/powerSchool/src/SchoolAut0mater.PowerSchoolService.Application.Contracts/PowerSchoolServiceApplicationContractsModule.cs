using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.PowerSchoolService;

[DependsOn(
    typeof(PowerSchoolServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class PowerSchoolServiceApplicationContractsModule : AbpModule
{

}
