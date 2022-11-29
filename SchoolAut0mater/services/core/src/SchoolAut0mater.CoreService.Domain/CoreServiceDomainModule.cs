using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.CoreService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(CoreServiceDomainSharedModule)
)]
public class CoreServiceDomainModule : AbpModule
{
}
