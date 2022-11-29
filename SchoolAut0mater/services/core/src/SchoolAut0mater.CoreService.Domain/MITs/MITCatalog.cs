using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;

using Volo.Abp;

namespace SchoolAut0mater.CoreService.MITs
{
    public class MITCatalog : Entity<int>, IHasConcurrencyStamp
    {
        [CanBeNull]
        public virtual string ParentCatalogCode { get; set; }

        [NotNull]
        public virtual string Code { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        public string DisplayName => $"{this.Name} ({this.Code})";

        [CanBeNull]
        public virtual List<string> LinkedFeatures { get; set; }

        public virtual bool IsFactory { get; set; }

        public virtual bool IsActive { get; set; }

        public string ConcurrencyStamp { get; set; }

        public MITCatalog() { }

        public MITCatalog(
            string code,
            string name,
            [CanBeNull] List<string> linkedFeatures = null,
            [CanBeNull] string parentCatalogCode = null,
            [CanBeNull] bool isFactory = false,
            [CanBeNull] bool isActive = true
        )
        {
            ConcurrencyStamp = Guid.NewGuid().ToString("N");

            Check.Length(parentCatalogCode, nameof(parentCatalogCode), MITCatalogConsts.ParentCatalogCodeMaxLength, 0);
            Check.NotNull(code, nameof(code));
            Check.Length(code, nameof(code), MITCatalogConsts.CodeMaxLength, MITCatalogConsts.CodeMinLength);
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), MITCatalogConsts.NameMaxLength, MITCatalogConsts.NameMinLength);
            Check.Length(linkedFeatures.ToString(), nameof(linkedFeatures), MITCatalogConsts.LinkedFeaturesMaxLength, MITCatalogConsts.LinkedFeaturesMinLength);
            ParentCatalogCode = parentCatalogCode;
            Code = code;
            Name = name;
            LinkedFeatures = linkedFeatures;
            IsFactory = isFactory;
            IsActive = isActive;
        }

    }
}