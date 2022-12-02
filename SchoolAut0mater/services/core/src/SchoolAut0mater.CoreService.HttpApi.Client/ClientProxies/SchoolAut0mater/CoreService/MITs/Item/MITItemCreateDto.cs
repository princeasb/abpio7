// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.ObjectExtending;
using SchoolAut0mater.CoreService.MITs.Item;
using System;

// ReSharper disable once CheckNamespace
namespace SchoolAut0mater.CoreService.MITs.Item;

public class MITItemCreateDto
{
    public int MITCatalogId { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public string DatabaseValue { get; set; }

    public string DisplayValue { get; set; }

    public int? SortOrder { get; set; }

    public bool? IsFactory { get; set; }

    public bool? IsActive { get; set; }
}
