using System;

namespace SchoolAut0mater.CoreService.MITs.Item
{
    public class MITItemExcelDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string DatabaseValue { get; set; }
        public string DisplayValue { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsFactory { get; set; }
        public bool? IsActive { get; set; }
    }
}