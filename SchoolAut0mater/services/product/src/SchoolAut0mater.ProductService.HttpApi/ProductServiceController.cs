using SchoolAut0mater.ProductService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SchoolAut0mater.ProductService;

public abstract class ProductServiceController : AbpController
{
    protected ProductServiceController()
    {
        LocalizationResource = typeof(ProductServiceResource);
    }
}
