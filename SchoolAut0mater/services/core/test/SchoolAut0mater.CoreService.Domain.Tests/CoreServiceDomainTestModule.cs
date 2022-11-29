using SchoolAut0mater.CoreService.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.CoreService;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(CoreServiceEntityFrameworkCoreTestModule)
    )]
public class CoreServiceDomainTestModule : AbpModule
{

}
