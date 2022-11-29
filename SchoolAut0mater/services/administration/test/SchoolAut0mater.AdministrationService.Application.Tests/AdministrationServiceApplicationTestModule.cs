using Volo.Abp.Modularity;

namespace SchoolAut0mater.AdministrationService;

[DependsOn(
    typeof(AdministrationServiceApplicationModule),
    typeof(AdministrationServiceDomainTestModule)
    )]
public class AdministrationServiceApplicationTestModule : AbpModule
{

}
