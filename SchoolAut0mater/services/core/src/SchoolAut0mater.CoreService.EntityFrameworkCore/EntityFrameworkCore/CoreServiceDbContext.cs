using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SchoolAut0mater.CoreService.EntityFrameworkCore;

[ConnectionStringName(CoreServiceDbProperties.ConnectionStringName)]
public class CoreServiceDbContext : AbpDbContext<CoreServiceDbContext>
{

    public CoreServiceDbContext(DbContextOptions<CoreServiceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureCoreService();
    }
}
