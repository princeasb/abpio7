using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SchoolAut0mater.PowerSchoolService.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
