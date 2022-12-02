using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolAut0mater.CoreService.MITs;
using Innofactor.EfCoreJsonValueConverter;
using Volo.Abp.EntityFrameworkCore.Modeling;
using System.Collections.Generic;

namespace SchoolAut0mater.CoreService.EntityTypeConfigurations.MITs
{
    public class MITItemConfigurations : IEntityTypeConfiguration<MITItem>
    {
        public void Configure(EntityTypeBuilder<MITItem> modelBuilder)
        {
            modelBuilder.ToTable(CoreServiceDbProperties.DbTablePrefix + "MITItems", "MIT");
            modelBuilder.ConfigureByConvention();
            modelBuilder.Property(x => x.TenantId).HasColumnName(nameof(MITItem.TenantId));
            modelBuilder.Property(x => x.Code).HasColumnName(nameof(MITItem.Code)).IsRequired().HasMaxLength(MITItemConsts.CodeMaxLength);
            modelBuilder.Property(x => x.Name).HasColumnName(nameof(MITItem.Name)).IsRequired().HasMaxLength(MITItemConsts.NameMaxLength);
            modelBuilder.Ignore(x => x.DisplayName);
            modelBuilder.Property(x => x.DatabaseValue).HasColumnName(nameof(MITItem.DatabaseValue)).IsRequired().HasMaxLength(MITItemConsts.DatabaseValueMaxLength);
            modelBuilder.Property(x => x.DisplayValue).HasColumnName(nameof(MITItem.DisplayValue)).IsRequired().HasMaxLength(MITItemConsts.DisplayValueMaxLength);
            modelBuilder.Property(x => x.SortOrder).HasColumnName(nameof(MITItem.SortOrder));
            modelBuilder.Property(x => x.IsFactory).HasColumnName(nameof(MITCatalog.IsFactory)).HasDefaultValue(false);
            modelBuilder.Property(x => x.IsActive).IsRequired(false).HasColumnName(nameof(MITCatalog.IsActive)).HasDefaultValue(true);
            modelBuilder.HasOne(x => x.MITCatalog).WithMany().IsRequired().HasForeignKey(x => x.MITCatalogId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
