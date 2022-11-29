using SchoolAut0mater.PowerSchoolService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SchoolAut0mater.PowerSchoolService;

public abstract class PowerSchoolServiceController : AbpControllerBase
{
    protected PowerSchoolServiceController()
    {
        LocalizationResource = typeof(PowerSchoolServiceResource);
    }
}
