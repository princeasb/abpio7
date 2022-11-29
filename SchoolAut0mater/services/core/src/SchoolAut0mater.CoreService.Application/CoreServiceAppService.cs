using SchoolAut0mater.CoreService.Localization;
using Volo.Abp.Application.Services;

namespace SchoolAut0mater.CoreService;

public abstract class CoreServiceAppService : ApplicationService
{
    protected CoreServiceAppService()
    {
        LocalizationResource = typeof(CoreServiceResource);
        ObjectMapperContext = typeof(CoreServiceApplicationModule);
    }
}
