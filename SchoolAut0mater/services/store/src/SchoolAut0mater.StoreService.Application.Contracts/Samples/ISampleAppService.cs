using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SchoolAut0mater.StoreService.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
