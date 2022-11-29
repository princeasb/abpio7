using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SchoolAut0mater.PowerSchoolService.EntityFrameworkCore;

[ConnectionStringName(PowerSchoolServiceDbProperties.ConnectionStringName)]
public class PowerSchoolServiceDbContext : AbpDbContext<PowerSchoolServiceDbContext>
{

    public PowerSchoolServiceDbContext(DbContextOptions<PowerSchoolServiceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigurePowerSchoolService();
    }
}
