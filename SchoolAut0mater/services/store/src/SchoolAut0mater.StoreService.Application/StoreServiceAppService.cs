using SchoolAut0mater.StoreService.Localization;
using Volo.Abp.Application.Services;

namespace SchoolAut0mater.StoreService;

public abstract class StoreServiceAppService : ApplicationService
{
    protected StoreServiceAppService()
    {
        LocalizationResource = typeof(StoreServiceResource);
        ObjectMapperContext = typeof(StoreServiceApplicationModule);
    }
}
