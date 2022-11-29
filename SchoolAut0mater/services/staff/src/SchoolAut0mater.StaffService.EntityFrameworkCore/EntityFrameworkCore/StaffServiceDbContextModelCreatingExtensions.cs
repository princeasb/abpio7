using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace SchoolAut0mater.StaffService.EntityFrameworkCore;

public static class StaffServiceDbContextModelCreatingExtensions
{
    public static void ConfigureStaffService(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(StaffServiceConsts.DbTablePrefix + "YourEntities", StaffServiceConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
