using Volo.Abp.Modularity;

namespace SchoolAut0mater.StaffService;

[DependsOn(
    typeof(StaffServiceApplicationModule),
    typeof(StaffServiceDomainTestModule)
    )]
public class StaffServiceApplicationTestModule : AbpModule
{

}
