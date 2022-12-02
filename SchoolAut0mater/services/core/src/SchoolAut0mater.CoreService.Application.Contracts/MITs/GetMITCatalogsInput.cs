using Volo.Abp.Application.Dtos;
using System;
using System.Collections.Generic;

namespace SchoolAut0mater.CoreService.MITs
{
    public class GetMITCatalogsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }
        // public List<string> LinkedFeatures { get; set; }
        // public string ParentCatalogCode { get; set; }
        // public bool? IsFactory { get; set; }
        // public bool? IsActive { get; set; }
        public GetMITCatalogsInput() { }
    }
}