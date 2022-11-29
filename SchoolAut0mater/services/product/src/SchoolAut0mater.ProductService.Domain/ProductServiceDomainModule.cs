using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.ProductService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ProductServiceDomainSharedModule)
)]
public class ProductServiceDomainModule : AbpModule
{

}
