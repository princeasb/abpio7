using Volo.Abp.EntityFrameworkCore.Modeling;
using SchoolAut0mater.CoreService.MITs;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace SchoolAut0mater.CoreService.EntityFrameworkCore;

public static class CoreServiceDbContextModelCreatingExtensions
{
    public static void ConfigureCoreService(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(CoreServiceConsts.DbTablePrefix + "YourEntities", CoreServiceConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        if (builder.IsHostDatabase())
        {
            builder.ApplyConfiguration(new EntityTypeConfigurations.MITs.MITCatalogConfigurations());
        }
        builder.ApplyConfiguration(new EntityTypeConfigurations.MITs.MITItemConfigurations());
    }
}