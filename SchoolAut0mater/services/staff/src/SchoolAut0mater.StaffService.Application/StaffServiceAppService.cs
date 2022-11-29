using SchoolAut0mater.StaffService.Localization;
using Volo.Abp.Application.Services;

namespace SchoolAut0mater.StaffService;

public abstract class StaffServiceAppService : ApplicationService
{
    protected StaffServiceAppService()
    {
        LocalizationResource = typeof(StaffServiceResource);
        ObjectMapperContext = typeof(StaffServiceApplicationModule);
    }
}
