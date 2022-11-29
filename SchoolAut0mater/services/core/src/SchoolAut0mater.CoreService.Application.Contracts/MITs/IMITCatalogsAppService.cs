using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SchoolAut0mater.CoreService.MITs
{
    public interface IMITCatalogsAppService : IApplicationService
    {
        Task<PagedResultDto<MITCatalogDto>> GetListAsync(GetMITCatalogsInput input);

        Task<MITCatalogDto> GetAsync(int id);
        Task<MITCatalogDto> GetAsync(string code);

        // Task<MITCatalogDto> CreateAsync(MITCatalogCreateDto input);
        // Task<MITCatalogDto> UpdateAsync(int id, MITCatalogUpdateDto input);
        // Task DeleteAsync(int id);
    }
}