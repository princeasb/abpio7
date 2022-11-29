using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.ProductService;

[DependsOn(
    typeof(ProductServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class ProductServiceApplicationContractsModule : AbpModule
{

}
