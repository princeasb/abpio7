using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using SchoolAut0mater.CoreService.Permissions;
using Microsoft.Extensions.Logging;

namespace SchoolAut0mater.CoreService.MITs
{

    [Authorize(CoreServicePermissions.MITCatalogs.Default)]
    public class MITCatalogsAppService : ApplicationService, IMITCatalogsAppService
    {

        private readonly IMITCatalogRepository _mITCatalogRepository;
        private readonly MITCatalogManager _mITCatalogManager;
        private readonly ILogger<MITCatalogsAppService> _logger;

        public MITCatalogsAppService(
            IMITCatalogRepository mITCatalogRepository, 
            MITCatalogManager mITCatalogManager,
            ILogger<MITCatalogsAppService> logger
        )
        {
            _mITCatalogRepository = mITCatalogRepository;
            _mITCatalogManager = mITCatalogManager;
            _logger = logger;
            logger.LogWarning("Initializing MITCatalogsAppService");
        }

        public virtual async Task<PagedResultDto<MITCatalogDto>> GetListAsync(GetMITCatalogsInput input)
        {
            _logger.LogWarning("Calling GetListAsync");
            var totalCount = await _mITCatalogRepository.GetCountAsync(
                input.FilterText
                // input.ParentCatalogCode, 
                // input.LinkedFeatures, 
                // input.IsFactory, 
                // input.IsActive
            );
            var items = await _mITCatalogRepository.GetListAsync(
                input.FilterText, 
                // input.ParentCatalogCode, 
                // input.LinkedFeatures, 
                // input.IsFactory, 
                // input.IsActive, 
                input.Sorting, 
                input.MaxResultCount, 
                input.SkipCount
            );

            return new PagedResultDto<MITCatalogDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<MITCatalog>, List<MITCatalogDto>>(items)
            };
        }

        public virtual async Task<MITCatalogDto> GetAsync(int id)
        {
            return ObjectMapper.Map<MITCatalog, MITCatalogDto>(await _mITCatalogRepository.GetAsync(id));
        }
        public virtual async Task<MITCatalogDto> GetAsync(string code)
        {
            var _mits = await _mITCatalogRepository.GetListAsync(c => c.Code == code);
            return ObjectMapper.Map<MITCatalog, MITCatalogDto>(_mits.FirstOrDefault());
        }

        [Authorize(CoreServicePermissions.MITCatalogs.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _mITCatalogRepository.DeleteAsync(id);
        }

        [Authorize(CoreServicePermissions.MITCatalogs.Create)]
        public virtual async Task<MITCatalogDto> CreateAsync(MITCatalogCreateDto input)
        {

            var mITCatalog = await _mITCatalogManager.CreateAsync(
                input.Code, 
                input.Name, 
                input.LinkedFeatures, 
                input.ParentCatalogCode, 
                input.IsFactory, 
                input.IsActive
            );

            return ObjectMapper.Map<MITCatalog, MITCatalogDto>(mITCatalog);
        }

        [Authorize(CoreServicePermissions.MITCatalogs.Edit)]
        public virtual async Task<MITCatalogDto> UpdateAsync(int id, MITCatalogUpdateDto input)
        {

            var mITCatalog = await _mITCatalogManager.UpdateAsync(
                id,
                input.Code, 
                input.Name,                 
                input.LinkedFeatures, 
                input.ParentCatalogCode, 
                input.IsFactory, 
                input.IsActive, 
                input.ConcurrencyStamp
            );

            return ObjectMapper.Map<MITCatalog, MITCatalogDto>(mITCatalog);
        }
    }
}