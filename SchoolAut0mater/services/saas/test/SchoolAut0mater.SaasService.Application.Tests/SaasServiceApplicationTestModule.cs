using SchoolAut0mater.SaasService.Application;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.SaasService;

[DependsOn(
    typeof(SaasServiceApplicationModule),
    typeof(SaasServiceDomainTestModule)
    )]
public class SaasServiceApplicationTestModule : AbpModule
{

}
