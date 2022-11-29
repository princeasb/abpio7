// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.ObjectExtending;
using SchoolAut0mater.CoreService.MITs;
using System;

// ReSharper disable once CheckNamespace
namespace SchoolAut0mater.CoreService.MITs;

public class MITCatalogUpdateDto
{
    public string ParentCatalogCode { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public string DisplayName { get; set; }

    public string[] LinkedFeatures { get; set; }

    public bool IsFactory { get; set; }

    public bool IsActive { get; set; }

    public string ConcurrencyStamp { get; set; }
}