using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SchoolAut0mater.StaffService.EntityFrameworkCore;

[ConnectionStringName(StaffServiceDbProperties.ConnectionStringName)]
public class StaffServiceDbContext : AbpDbContext<StaffServiceDbContext>
{

    public StaffServiceDbContext(DbContextOptions<StaffServiceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureStaffService();
    }
}
