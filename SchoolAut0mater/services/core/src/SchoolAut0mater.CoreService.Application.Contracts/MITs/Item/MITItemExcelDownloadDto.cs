using Volo.Abp.Application.Dtos;
using System;

namespace SchoolAut0mater.CoreService.MITs.Item
{
    public class MITItemExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string FilterText { get; set; }

        public int? MITCatalogId { get; set; }
        public string MITCatalogCode { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }

        public string DatabaseValue { get; set; }
        public string DisplayValue { get; set; }

        public int? SortOrderMin { get; set; }
        public int? SortOrderMax { get; set; }
        public bool? IsFactory { get; set; }
        public bool? IsActive { get; set; }

        public MITItemExcelDownloadDto() { }
    }
}