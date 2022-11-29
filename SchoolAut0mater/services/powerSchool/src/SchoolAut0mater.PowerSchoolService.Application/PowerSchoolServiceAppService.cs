using SchoolAut0mater.PowerSchoolService.Localization;
using Volo.Abp.Application.Services;

namespace SchoolAut0mater.PowerSchoolService;

public abstract class PowerSchoolServiceAppService : ApplicationService
{
    protected PowerSchoolServiceAppService()
    {
        LocalizationResource = typeof(PowerSchoolServiceResource);
        ObjectMapperContext = typeof(PowerSchoolServiceApplicationModule);
    }
}
