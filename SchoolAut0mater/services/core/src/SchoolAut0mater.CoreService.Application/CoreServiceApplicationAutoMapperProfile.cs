using System;
using SchoolAut0mater.CoreService.Shared;
using Volo.Abp.AutoMapper;
using SchoolAut0mater.CoreService.MITs;
using AutoMapper;
using SchoolAut0mater.CoreService.MITs.Catalog;
using SchoolAut0mater.CoreService.MITs.Item;

namespace SchoolAut0mater.CoreService;

public class CoreServiceApplicationAutoMapperProfile : Profile
{
    public CoreServiceApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
        * Alternatively, you can split your mapping configurations
        * into multiple profile classes for a better organization. */

        CreateMap<MITCatalog, MITCatalogDto>();

        CreateMap<MITItem, MITItemDto>();
        CreateMap<MITItem, MITItemExcelDto>();
        CreateMap<MITItemWithNavigationProperties, MITItemWithNavigationPropertiesDto>();
        CreateMap<MITCatalog, LookupDto<int>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName));
    }
}