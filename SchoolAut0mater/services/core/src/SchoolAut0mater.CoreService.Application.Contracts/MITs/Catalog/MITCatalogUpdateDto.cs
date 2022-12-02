using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace SchoolAut0mater.CoreService.MITs.Catalog
{
    public class MITCatalogUpdateDto : IHasConcurrencyStamp
    {
        [StringLength(MITCatalogConsts.ParentCatalogCodeMaxLength)]
        public string ParentCatalogCode { get; set; }

        [Required]
        [StringLength(MITCatalogConsts.CodeMaxLength, MinimumLength = MITCatalogConsts.CodeMinLength)]
        public string Code { get; set; }

        [Required]
        [StringLength(MITCatalogConsts.NameMaxLength, MinimumLength = MITCatalogConsts.NameMinLength)]

        public string Name { get; set; }

        public string DisplayName { get; set; }

        [StringLength(MITCatalogConsts.LinkedFeaturesMaxLength, MinimumLength = MITCatalogConsts.LinkedFeaturesMinLength)]
        public List<string> LinkedFeatures { get; set; }

        public bool IsFactory { get; set; }

        public bool IsActive { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}