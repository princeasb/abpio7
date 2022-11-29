using SchoolAut0mater.StoreService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SchoolAut0mater.StoreService;

public abstract class StoreServiceController : AbpControllerBase
{
    protected StoreServiceController()
    {
        LocalizationResource = typeof(StoreServiceResource);
    }
}
