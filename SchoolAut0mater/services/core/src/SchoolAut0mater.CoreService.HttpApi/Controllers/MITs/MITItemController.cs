using SchoolAut0mater.CoreService.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Content;
using SchoolAut0mater.CoreService.MITs.Item;

namespace SchoolAut0mater.CoreService.MITs
{
    [RemoteService(Name = "CoreService")]
    [Area("coreService")]
    [ControllerName("MITItem")]
    [Route("api/core-service/mitItems")]
    public class MITItemController : AbpController, IMITItemsAppService
    {
        private readonly IMITItemsAppService _mITItemsAppService;

        public MITItemController(IMITItemsAppService mITItemsAppService)
        {
            _mITItemsAppService = mITItemsAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<MITItemWithNavigationPropertiesDto>> GetListAsync(GetMITItemsInput input)
        {
            return _mITItemsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<MITItemWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(int id)
        {
            return _mITItemsAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<MITItemDto> GetAsync(int id)
        {
            return _mITItemsAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("mitCatalog-lookup")]
        public Task<PagedResultDto<LookupDto<int>>> GetMITCatalogLookupAsync(LookupRequestDto input)
        {
            return _mITItemsAppService.GetMITCatalogLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<MITItemDto> CreateAsync(MITItemCreateDto input)
        {
            return _mITItemsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<MITItemDto> UpdateAsync(int id, MITItemUpdateDto input)
        {
            return _mITItemsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _mITItemsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(MITItemExcelDownloadDto input)
        {
            return _mITItemsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _mITItemsAppService.GetDownloadTokenAsync();
        }
    }
}