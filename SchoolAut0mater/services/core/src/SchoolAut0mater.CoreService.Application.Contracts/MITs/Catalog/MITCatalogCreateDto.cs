using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SchoolAut0mater.CoreService.MITs.Catalog
{
    public class MITCatalogCreateDto
    {
        [StringLength(MITCatalogConsts.ParentCatalogCodeMaxLength)]
        public string ParentCatalogCode { get; set; }

        [Required]
        [StringLength(MITCatalogConsts.CodeMaxLength, MinimumLength = MITCatalogConsts.CodeMinLength)]
        public string Code { get; set; }

        [Required]
        [StringLength(MITCatalogConsts.NameMaxLength, MinimumLength = MITCatalogConsts.NameMinLength)]
        public string Name { get; set; }

        [StringLength(MITCatalogConsts.LinkedFeaturesMaxLength, MinimumLength = MITCatalogConsts.LinkedFeaturesMinLength)]
        public List<string> LinkedFeatures { get; set; }

        public bool IsFactory { get; set; } = false;

        public bool IsActive { get; set; } = true;
    }
}