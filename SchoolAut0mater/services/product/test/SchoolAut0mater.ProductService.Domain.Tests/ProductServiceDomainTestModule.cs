using SchoolAut0mater.ProductService.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.ProductService;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(ProductServiceEntityFrameworkCoreTestModule)
    )]
public class ProductServiceDomainTestModule : AbpModule
{

}
