using SchoolAut0mater.CoreService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SchoolAut0mater.CoreService;

public abstract class CoreServiceController : AbpController //Base
{
    protected CoreServiceController()
    {
        LocalizationResource = typeof(CoreServiceResource);
    }
}
