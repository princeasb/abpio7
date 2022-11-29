using SchoolAut0mater.StoreService.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.StoreService;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(StoreServiceEntityFrameworkCoreTestModule)
    )]
public class StoreServiceDomainTestModule : AbpModule
{

}
