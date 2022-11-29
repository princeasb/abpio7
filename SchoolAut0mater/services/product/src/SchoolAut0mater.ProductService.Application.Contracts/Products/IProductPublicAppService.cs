﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SchoolAut0mater.ProductService.Products;

public interface IProductPublicAppService : IApplicationService
{
    Task<List<ProductDto>> GetListAsync();
}
