using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolAut0mater.CoreService.MITs;
using Innofactor.EfCoreJsonValueConverter;
using Volo.Abp.EntityFrameworkCore.Modeling;
using System.Collections.Generic;

namespace SchoolAut0mater.CoreService.EntityTypeConfigurations.MITs
{
    public class MITCatalogConfigurations : IEntityTypeConfiguration<MITCatalog>
    {
        public void Configure(EntityTypeBuilder<MITCatalog> modelBuilder)
        {
            modelBuilder.ToTable(CoreServiceDbProperties.DbTablePrefix + "MITCatalogs", "MIT");
            modelBuilder.ConfigureByConvention();
            modelBuilder.Property(x => x.ParentCatalogCode).HasColumnName(nameof(MITCatalog.ParentCatalogCode)).HasMaxLength(MITCatalogConsts.ParentCatalogCodeMaxLength);
            modelBuilder.Property(x => x.Code).HasColumnName(nameof(MITCatalog.Code)).IsRequired().HasMaxLength(MITCatalogConsts.CodeMaxLength);
            modelBuilder.Property(x => x.Name).HasColumnName(nameof(MITCatalog.Name)).IsRequired().HasMaxLength(MITCatalogConsts.NameMaxLength);
            modelBuilder.Ignore(x => x.DisplayName);
            #region LinkedFeatures
            // https://github.com/Innofactor/EfCoreJsonValueConverter
            modelBuilder.Property(p => p.LinkedFeatures)
                .HasJsonValueConversion()
                .HasColumnName(nameof(MITCatalog.LinkedFeatures))
                .HasMaxLength(MITCatalogConsts.LinkedFeaturesMaxLength)
                .HasDefaultValue<List<string>>(new List<string> { "*" });
            #endregion LinkedFeatures
            modelBuilder.Property(x => x.IsFactory).HasColumnName(nameof(MITCatalog.IsFactory)).HasDefaultValue(false);
            modelBuilder.Property(x => x.IsActive).HasColumnName(nameof(MITCatalog.IsActive)).HasDefaultValue(true);
        }
    }
}
