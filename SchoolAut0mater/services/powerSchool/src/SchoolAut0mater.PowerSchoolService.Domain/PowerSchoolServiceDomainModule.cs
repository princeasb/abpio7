using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.PowerSchoolService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(PowerSchoolServiceDomainSharedModule)
)]
public class PowerSchoolServiceDomainModule : AbpModule
{
}
