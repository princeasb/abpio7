using SchoolAut0mater.IdentityService.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.IdentityService;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(IdentityServiceEntityFrameworkCoreTestModule)
    )]
public class IdentityServiceDomainTestModule : AbpModule
{

}
