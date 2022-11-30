using SchoolAut0mater.CoreService.MITs;
using AutoMapper;

namespace SchoolAut0mater.CoreService;

public class CoreServiceApplicationAutoMapperProfile : Profile
{
    public CoreServiceApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
        * Alternatively, you can split your mapping configurations
        * into multiple profile classes for a better organization. */

        CreateMap<MITCatalog, MITCatalogDto>();
    }
}