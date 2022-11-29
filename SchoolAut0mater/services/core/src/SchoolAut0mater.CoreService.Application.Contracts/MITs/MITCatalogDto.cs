using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace SchoolAut0mater.CoreService.MITs
{
    public class MITCatalogDto : EntityDto<int>, IHasConcurrencyStamp
    {
        public string ParentCatalogCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public List<string> LinkedFeatures { get; set; }
        public bool IsFactory { get; set; }
        public bool IsActive { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}