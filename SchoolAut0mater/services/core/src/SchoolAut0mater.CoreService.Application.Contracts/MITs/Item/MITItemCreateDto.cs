using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SchoolAut0mater.CoreService.MITs.Item
{
    public class MITItemCreateDto
    {
        [Required]
        public int MITCatalogId { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9.-]*")]
        [StringLength(MITItemConsts.CodeMaxLength, MinimumLength = MITItemConsts.CodeMinLength)]
        public string Code { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9\\-_ .]*")]
        [StringLength(MITItemConsts.NameMaxLength, MinimumLength = MITItemConsts.NameMinLength)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9\\-_ .]*")]
        [StringLength(MITItemConsts.DatabaseValueMaxLength, MinimumLength = MITItemConsts.DatabaseValueMinLength)]
        public string DatabaseValue { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9\\-_ .]*")]
        [StringLength(MITItemConsts.DisplayValueMaxLength, MinimumLength = MITItemConsts.DisplayValueMinLength)]
        public string DisplayValue { get; set; }

        public int? SortOrder { get; set; }
        public bool? IsFactory { get; set; } = false;
        public bool? IsActive { get; set; } = true;
    }
}