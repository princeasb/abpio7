using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SchoolAut0mater.CoreService.Settings
{
    public interface ICoreServiceSettingsAppService : IApplicationService
    {
        Task<CoreServiceSettingsDto> GetAsync();
        Task UpdateAsync(UpdateCoreServiceSettingsDto input);
    }
}
