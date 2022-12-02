using SchoolAut0mater.CoreService.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace SchoolAut0mater.CoreService.MITs.Item
{
    public interface IMITItemsAppService : IApplicationService
    {
        Task<PagedResultDto<MITItemWithNavigationPropertiesDto>> GetListAsync(GetMITItemsInput input);

        Task<MITItemWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(int id);

        Task<MITItemDto> GetAsync(int id);

        Task<PagedResultDto<LookupDto<int>>> GetMITCatalogLookupAsync(LookupRequestDto input);

        Task DeleteAsync(int id);

        Task<MITItemDto> CreateAsync(MITItemCreateDto input);

        Task<MITItemDto> UpdateAsync(int id, MITItemUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(MITItemExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}