using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace SchoolAut0mater.StoreService.EntityFrameworkCore;

public static class StoreServiceDbContextModelCreatingExtensions
{
    public static void ConfigureStoreService(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(StoreServiceConsts.DbTablePrefix + "YourEntities", StoreServiceConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
