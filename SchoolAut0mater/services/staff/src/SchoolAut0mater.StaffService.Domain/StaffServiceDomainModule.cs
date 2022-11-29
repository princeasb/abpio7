using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.StaffService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(StaffServiceDomainSharedModule)
)]
public class StaffServiceDomainModule : AbpModule
{
}
