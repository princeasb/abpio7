using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace SchoolAut0mater.CoreService.MITs.Item
{
    public class MITItemDto : FullAuditedEntityDto<int>, IHasConcurrencyStamp
    {
        public int MITCatalogId { get; set; }
        public string MITCatalogCode { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string DatabaseValue { get; set; }
        public string DisplayValue { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsFactory { get; set; }
        public bool? IsActive { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}