using Volo.Abp.Modularity;

namespace SchoolAut0mater.CoreService;

[DependsOn(
    typeof(CoreServiceApplicationModule),
    typeof(CoreServiceDomainTestModule)
    )]
public class CoreServiceApplicationTestModule : AbpModule
{

}
