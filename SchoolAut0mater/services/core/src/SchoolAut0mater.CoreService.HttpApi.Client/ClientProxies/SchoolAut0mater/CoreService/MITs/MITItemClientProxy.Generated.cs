// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using SchoolAut0mater.CoreService.MITs;
using SchoolAut0mater.CoreService.MITs.Item;
using SchoolAut0mater.CoreService.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Content;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Client.ClientProxying;
using Volo.Abp.Http.Modeling;

// ReSharper disable once CheckNamespace
namespace SchoolAut0mater.CoreService.MITs;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IMITItemsAppService), typeof(MITItemClientProxy))]
public partial class MITItemClientProxy : ClientProxyBase<IMITItemsAppService>, IMITItemsAppService
{
    public virtual async Task<PagedResultDto<MITItemWithNavigationPropertiesDto>> GetListAsync(GetMITItemsInput input)
    {
        return await RequestAsync<PagedResultDto<MITItemWithNavigationPropertiesDto>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(GetMITItemsInput), input }
        });
    }

    public virtual async Task<MITItemWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(int id)
    {
        return await RequestAsync<MITItemWithNavigationPropertiesDto>(nameof(GetWithNavigationPropertiesAsync), new ClientProxyRequestTypeValue
        {
            { typeof(int), id }
        });
    }

    public virtual async Task<MITItemDto> GetAsync(int id)
    {
        return await RequestAsync<MITItemDto>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(int), id }
        });
    }

    public virtual async Task<PagedResultDto<LookupDto<Int32>>> GetMITCatalogLookupAsync(LookupRequestDto input)
    {
        return await RequestAsync<PagedResultDto<LookupDto<Int32>>>(nameof(GetMITCatalogLookupAsync), new ClientProxyRequestTypeValue
        {
            { typeof(LookupRequestDto), input }
        });
    }

    public virtual async Task<MITItemDto> CreateAsync(MITItemCreateDto input)
    {
        return await RequestAsync<MITItemDto>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(MITItemCreateDto), input }
        });
    }

    public virtual async Task<MITItemDto> UpdateAsync(int id, MITItemUpdateDto input)
    {
        return await RequestAsync<MITItemDto>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(int), id },
            { typeof(MITItemUpdateDto), input }
        });
    }

    public virtual async Task DeleteAsync(int id)
    {
        await RequestAsync(nameof(DeleteAsync), new ClientProxyRequestTypeValue
        {
            { typeof(int), id }
        });
    }

    public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(MITItemExcelDownloadDto input)
    {
        return await RequestAsync<IRemoteStreamContent>(nameof(GetListAsExcelFileAsync), new ClientProxyRequestTypeValue
        {
            { typeof(MITItemExcelDownloadDto), input }
        });
    }

    public virtual async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
    {
        return await RequestAsync<DownloadTokenResultDto>(nameof(GetDownloadTokenAsync));
    }
}
