using AutoMapper;
using SchoolAut0mater.ProductService.Products;

namespace SchoolAut0mater.ProductService;

public class ProductServiceApplicationAutoMapperProfile : Profile
{
    public ProductServiceApplicationAutoMapperProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}
