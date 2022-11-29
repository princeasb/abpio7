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
using SchoolAut0mater.CoreService.MITs;
using Volo.Abp.ObjectMapping;

namespace SchoolAut0mater.CoreService.MITs
{

    [Authorize(CoreServicePermissions.MITCatalogs.Default)]
    public class MITCatalogsAppService : ApplicationService, IMITCatalogsAppService
    {

        private readonly IMITCatalogRepository _mITCatalogRepository;
        private readonly MITCatalogManager _mITCatalogManager;

        public MITCatalogsAppService(IMITCatalogRepository mITCatalogRepository, MITCatalogManager mITCatalogManager)
        {

            _mITCatalogRepository = mITCatalogRepository;
            _mITCatalogManager = mITCatalogManager;
        }

        public virtual async Task<PagedResultDto<MITCatalogDto>> GetListAsync(GetMITCatalogsInput input)
        {
            var totalCount = await _mITCatalogRepository.GetCountAsync(
                input.FilterText, 
                input.Code, 
                input.Name, 
                input.LinkedFeatures, 
                input.ParentCatalogCode, 
                input.IsFactory, 
                input.IsActive
            );
            var items = await _mITCatalogRepository.GetListAsync(
                input.FilterText, 
                input.Code, 
                input.Name, 
                input.LinkedFeatures, 
                input.ParentCatalogCode, 
                input.IsFactory, 
                input.IsActive, 
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