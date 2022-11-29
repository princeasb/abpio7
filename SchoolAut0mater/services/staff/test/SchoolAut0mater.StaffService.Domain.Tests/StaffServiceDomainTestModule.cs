using SchoolAut0mater.StaffService.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.StaffService;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(StaffServiceEntityFrameworkCoreTestModule)
    )]
public class StaffServiceDomainTestModule : AbpModule
{

}
