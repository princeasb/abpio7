using SchoolAut0mater.ProductService.Localization;
using Volo.Abp.Application.Services;

namespace SchoolAut0mater.ProductService;

public abstract class ProductServiceAppService : ApplicationService
{
    protected ProductServiceAppService()
    {
        LocalizationResource = typeof(ProductServiceResource);
        ObjectMapperContext = typeof(ProductServiceApplicationModule);
    }
}
