// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.ObjectExtending;
using SchoolAut0mater.CoreService.MITs.Catalog;
using System;
using Volo.Abp.Application.Dtos;

// ReSharper disable once CheckNamespace
namespace SchoolAut0mater.CoreService.MITs.Catalog;

public class GetMITCatalogsInput : PagedAndSortedResultRequestDto
{
    public string FilterText { get; set; }
}
