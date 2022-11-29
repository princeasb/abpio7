using Volo.Abp.Modularity;

namespace SchoolAut0mater.ProductService;

[DependsOn(
    typeof(ProductServiceApplicationModule),
    typeof(ProductServiceDomainTestModule)
    )]
public class ProductServiceApplicationTestModule : AbpModule
{

}
