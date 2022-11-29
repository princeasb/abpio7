using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using SchoolAut0mater.CoreService.MITs;
using System.Linq;

namespace SchoolAut0mater.CoreService.MITs
{
    [RemoteService(Name = "CoreService")]
    [Area("coreService")]
    [ControllerName("MITCatalog")]
    [Route("api/core-service/mitCatalogs")]
    public class MITCatalogController : AbpController, IMITCatalogsAppService
    {
        private readonly IMITCatalogsAppService _mITCatalogsAppService;

        public MITCatalogController(IMITCatalogsAppService mITCatalogsAppService)
        {
            _mITCatalogsAppService = mITCatalogsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<MITCatalogDto>> GetListAsync(GetMITCatalogsInput input)
        {
            return _mITCatalogsAppService.GetListAsync(input);
        }

        [HttpGet, Route("{id}")]
        public virtual Task<MITCatalogDto> GetAsync(int id) => _mITCatalogsAppService.GetAsync(id);

        [HttpGet, Route("{code}")]
        public virtual Task<MITCatalogDto> GetAsync(string code) => _mITCatalogsAppService.GetAsync(code);


        // [HttpPost] public virtual Task<MITCatalogDto> CreateAsync(MITCatalogCreateDto input) => _mITCatalogsAppService.CreateAsync(input);
        // [HttpPut, Route("{id}")] public virtual Task<MITCatalogDto> UpdateAsync(int id, MITCatalogUpdateDto input) => _mITCatalogsAppService.UpdateAsync(id, input);
        // [HttpDelete, Route("{id}")] public virtual Task DeleteAsync(int id) => _mITCatalogsAppService.DeleteAsync(id);
    }
}