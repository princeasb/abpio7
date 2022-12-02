using System;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;
using SchoolAut0mater.CoreService.MITs.Catalog;
using SchoolAut0mater.CoreService.MITs.Item;

namespace SchoolAut0mater.CoreService.MITs
{
    public class MITItemWithNavigationPropertiesDto
    {
        public MITItemDto MITItem { get; set; }

        public MITCatalogDto MITCatalog { get; set; }

    }
}