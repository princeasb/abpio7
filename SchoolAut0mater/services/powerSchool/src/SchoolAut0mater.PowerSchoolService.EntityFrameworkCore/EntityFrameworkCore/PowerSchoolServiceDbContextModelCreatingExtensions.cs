using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace SchoolAut0mater.PowerSchoolService.EntityFrameworkCore;

public static class PowerSchoolServiceDbContextModelCreatingExtensions
{
    public static void ConfigurePowerSchoolService(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(PowerSchoolServiceConsts.DbTablePrefix + "YourEntities", PowerSchoolServiceConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
