using SchoolAut0mater.StaffService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SchoolAut0mater.StaffService;

public abstract class StaffServiceController : AbpControllerBase
{
    protected StaffServiceController()
    {
        LocalizationResource = typeof(StaffServiceResource);
    }
}
