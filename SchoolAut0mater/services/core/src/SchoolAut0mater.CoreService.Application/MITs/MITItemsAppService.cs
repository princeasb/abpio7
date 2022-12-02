using SchoolAut0mater.CoreService.Shared;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using SchoolAut0mater.CoreService.Permissions;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using SchoolAut0mater.CoreService.MITs.Item;
using Microsoft.Extensions.Logging;

namespace SchoolAut0mater.CoreService.MITs
{

    [Authorize(CoreServicePermissions.MITItems.Default)]
    public class MITItemsAppService : ApplicationService, IMITItemsAppService
    {
        private readonly IDistributedCache<MITItemExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IMITItemRepository _mITItemRepository;
        private readonly MITItemManager _mITItemManager;
        private readonly IRepository<MITCatalog, int> _mITCatalogRepository;
        private readonly ILogger<MITItemsAppService> _logger;

        public MITItemsAppService(
            IMITItemRepository mITItemRepository,
            MITItemManager mITItemManager,
            IDistributedCache<MITItemExcelDownloadTokenCacheItem, string> excelDownloadTokenCache,
            IRepository<MITCatalog, int> mITCatalogRepository,
            ILogger<MITItemsAppService> logger
        )
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _mITItemRepository = mITItemRepository;
            _mITItemManager = mITItemManager; _mITCatalogRepository = mITCatalogRepository;
            _logger = logger;
            logger.LogWarning("Initializing MITItemsAppService");
        }

        public virtual async Task<PagedResultDto<MITItemWithNavigationPropertiesDto>> GetListAsync(GetMITItemsInput input)
        {
            var totalCount = await _mITItemRepository.GetCountAsync(
                input.FilterText, 
                input.Code, 
                input.Name, 
                input.DatabaseValue, 
                input.DisplayValue, 
                input.SortOrderMin, 
                input.SortOrderMax, 
                input.IsFactory, 
                input.IsActive, 
                input.MITCatalogCode
            );
            var items = await _mITItemRepository.GetListWithNavigationPropertiesAsync(
                input.FilterText, 
                input.Code, 
                input.Name, 
                input.DatabaseValue, 
                input.DisplayValue, 
                input.SortOrderMin, 
                input.SortOrderMax, 
                input.IsFactory, 
                input.IsActive, 
                input.MITCatalogCode, 
                input.Sorting, 
                input.MaxResultCount, 
                input.SkipCount
            );

            return new PagedResultDto<MITItemWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<MITItemWithNavigationProperties>, List<MITItemWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<MITItemWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(int id)
        {
            return ObjectMapper.Map<MITItemWithNavigationProperties, MITItemWithNavigationPropertiesDto>
                (await _mITItemRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<MITItemDto> GetAsync(int id)
        {
            return ObjectMapper.Map<MITItem, MITItemDto>(await _mITItemRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<int>>> GetMITCatalogLookupAsync(LookupRequestDto input)
        {
            var query = (await _mITCatalogRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.DisplayName != null &&
                         x.DisplayName.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<MITCatalog>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<int>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<MITCatalog>, List<LookupDto<int>>>(lookupData)
            };
        }

        [Authorize(CoreServicePermissions.MITItems.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _mITItemRepository.DeleteAsync(id);
        }

        [Authorize(CoreServicePermissions.MITItems.Create)]
        public virtual async Task<MITItemDto> CreateAsync(MITItemCreateDto input)
        {
            if (input.MITCatalogId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MITCatalog"]]);
            }

            var mITItem = await _mITItemManager.CreateAsync(
                input.MITCatalogId, 
                input.Code, 
                input.Name, 
                input.DatabaseValue, 
                input.DisplayValue, 
                input.SortOrder, 
                input.IsFactory, 
                input.IsActive
            );

            return ObjectMapper.Map<MITItem, MITItemDto>(mITItem);
        }

        [Authorize(CoreServicePermissions.MITItems.Edit)]
        public virtual async Task<MITItemDto> UpdateAsync(int id, MITItemUpdateDto input)
        {
            var mITItem = await _mITItemManager.UpdateAsync(
                id,
                input.Name, 
                input.DatabaseValue, 
                input.DisplayValue, 
                input.SortOrder, 
                input.IsActive, 
                input.ConcurrencyStamp
            );

            return ObjectMapper.Map<MITItem, MITItemDto>(mITItem);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(MITItemExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _mITItemRepository.GetListAsync(
                input.FilterText,
                input.Code, 
                input.Name, 
                input.DatabaseValue, 
                input.DisplayValue, 
                input.SortOrderMin, 
                input.SortOrderMax, 
                input.IsFactory, 
                input.IsActive
            );

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<MITItem>, List<MITItemExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "MITItems.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new MITItemExcelDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}