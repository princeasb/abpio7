using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace SchoolAut0mater.PowerSchoolService.Samples;

[RemoteService(Name = PowerSchoolServiceRemoteServiceConsts.RemoteServiceName)]
[Area("PowerSchoolService")]
[ControllerName("PowerSchoolService")]
[Route("api/PowerSchoolService/sample")]
public class SampleController : PowerSchoolServiceController, ISampleAppService
{
    private readonly ISampleAppService _sampleAppService;

    public SampleController(ISampleAppService sampleAppService)
    {
        _sampleAppService = sampleAppService;
    }

    [HttpGet]
    public async Task<SampleDto> GetAsync()
    {
        return await _sampleAppService.GetAsync();
    }

    [HttpGet]
    [Route("authorized")]
    public async Task<SampleDto> GetAuthorizedAsync()
    {
        return await _sampleAppService.GetAsync();
    }
}
