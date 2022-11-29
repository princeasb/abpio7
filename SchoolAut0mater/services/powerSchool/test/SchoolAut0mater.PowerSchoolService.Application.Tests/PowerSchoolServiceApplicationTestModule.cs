using Volo.Abp.Modularity;

namespace SchoolAut0mater.PowerSchoolService;

[DependsOn(
    typeof(PowerSchoolServiceApplicationModule),
    typeof(PowerSchoolServiceDomainTestModule)
    )]
public class PowerSchoolServiceApplicationTestModule : AbpModule
{

}
