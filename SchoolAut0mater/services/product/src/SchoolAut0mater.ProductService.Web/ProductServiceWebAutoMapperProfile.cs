using AutoMapper;
using SchoolAut0mater.ProductService.Products;

namespace SchoolAut0mater.ProductService.Web;

public class ProductServiceWebAutoMapperProfile : Profile
{
    public ProductServiceWebAutoMapperProfile()
    {
        CreateMap<ProductDto, ProductUpdateDto>();
    }
}
