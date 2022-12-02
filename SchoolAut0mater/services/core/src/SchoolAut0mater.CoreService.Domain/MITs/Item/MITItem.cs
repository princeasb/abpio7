using SchoolAut0mater.CoreService.MITs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAut0mater.CoreService.MITs
{
    public class MITItem : FullAuditedEntity<int>, IMultiTenant, IHasConcurrencyStamp
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual int MITCatalogId { get; set; }

        [ForeignKey("MITCatalogId")]
        public MITCatalog MITCatalog { get; set; }

        [NotNull]
        public virtual string Code { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public string DisplayName => $"{this.Name} ({this.Code})";

        [NotNull]
        public virtual string DatabaseValue { get; set; }

        [NotNull]
        public virtual string DisplayValue { get; set; }

        public virtual int? SortOrder { get; set; }

        public virtual bool? IsFactory { get; set; }

        public virtual bool? IsActive { get; set; }

        public string ConcurrencyStamp { get; set; }

        public MITItem() { }

        public MITItem(
            int mITCatalogId,
            string code,
            string name,
            string databaseValue,
            string displayValue,
            int? sortOrder = null,
            bool? isFactory = null,
            bool? isActive = null
        )
        {
            ConcurrencyStamp = Guid.NewGuid().ToString("N");

            Check.NotNull(code, nameof(code));
            Check.Length(code, nameof(code), MITItemConsts.CodeMaxLength, MITItemConsts.CodeMinLength);
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), MITItemConsts.NameMaxLength, MITItemConsts.NameMinLength);
            Check.NotNull(databaseValue, nameof(databaseValue));
            Check.Length(databaseValue, nameof(databaseValue), MITItemConsts.DatabaseValueMaxLength, MITItemConsts.DatabaseValueMinLength);
            Check.NotNull(displayValue, nameof(displayValue));
            Check.Length(displayValue, nameof(displayValue), MITItemConsts.DisplayValueMaxLength, MITItemConsts.DisplayValueMinLength);
            MITCatalogId = mITCatalogId;
            Code = code;
            Name = name;
            DatabaseValue = databaseValue;
            DisplayValue = displayValue;
            SortOrder = sortOrder;
            IsFactory = isFactory;
            IsActive = isActive;
        }

    }
}