using Microsoft.EntityFrameworkCore;
using SchoolAut0mater.ProductService.Products;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SchoolAut0mater.ProductService.EntityFrameworkCore;

public static class ProductServiceDbContextModelCreatingExtensions
{
    public static void ConfigureProductService(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Product>(b =>
        {
            b.ToTable(ProductServiceDbProperties.DbTablePrefix + "Products", ProductServiceDbProperties.DbSchema);

            b.ConfigureByConvention();

            b.Property(x => x.TenantId).HasColumnName(nameof(Product.TenantId));
            b.Property(x => x.Name).HasColumnName(nameof(Product.Name)).IsRequired().HasMaxLength(ProductConsts.NameMaxLength);
            b.Property(x => x.Price).HasColumnName(nameof(Product.Price)).IsRequired();

            b.HasIndex(x => new { x.TenantId, x.Name });
        });
    }
}
