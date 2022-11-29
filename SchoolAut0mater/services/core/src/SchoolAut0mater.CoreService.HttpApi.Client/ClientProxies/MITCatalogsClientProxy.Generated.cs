// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client.ClientProxying;
using SchoolAut0mater.CoreService.MITs;
using Volo.Abp.Content;
using SchoolAut0mater.CoreService.Shared;

// ReSharper disable once CheckNamespace
namespace SchoolAut0mater.CoreService.MITs.ClientProxies;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IMITCatalogsAppService), typeof(MITCatalogsClientProxy))]
public partial class MITCatalogsClientProxy : ClientProxyBase<IMITCatalogsAppService>, IMITCatalogsAppService
{
    public virtual async Task<PagedResultDto<MITCatalogDto>> GetListAsync(GetMITCatalogsInput input)
    {
        return await RequestAsync<PagedResultDto<MITCatalogDto>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(GetMITCatalogsInput), input }
        });
    }

    public virtual async Task<MITCatalogDto> GetAsync(int id)
    {
        return await RequestAsync<MITCatalogDto>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(int), id }
        });
    }

    public virtual async Task DeleteAsync(int id)
    {
        await RequestAsync(nameof(DeleteAsync), new ClientProxyRequestTypeValue
        {
            { typeof(int), id }
        });
    }

    public virtual async Task<MITCatalogDto> CreateAsync(MITCatalogCreateDto input)
    {
        return await RequestAsync<MITCatalogDto>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(MITCatalogCreateDto), input }
        });
    }

    public virtual async Task<MITCatalogDto> UpdateAsync(int id, MITCatalogUpdateDto input)
    {
        return await RequestAsync<MITCatalogDto>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(int), id },
            { typeof(MITCatalogUpdateDto), input }
        });
    }
}