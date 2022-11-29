﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolAut0mater.ProductService.Products;

public class ProductPublicAppService : ProductServiceAppService, IProductPublicAppService
{
    private readonly IProductRepository _productRepository;

    public ProductPublicAppService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public virtual async Task<List<ProductDto>> GetListAsync()
    {
        return ObjectMapper.Map<List<Product>, List<ProductDto>>(await _productRepository.GetListAsync());
    }
}
