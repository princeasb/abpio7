using SchoolAut0mater.PowerSchoolService.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.PowerSchoolService;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(PowerSchoolServiceEntityFrameworkCoreTestModule)
    )]
public class PowerSchoolServiceDomainTestModule : AbpModule
{

}
