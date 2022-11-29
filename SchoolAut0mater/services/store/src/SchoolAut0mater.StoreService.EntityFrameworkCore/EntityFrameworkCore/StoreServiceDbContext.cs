using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SchoolAut0mater.StoreService.EntityFrameworkCore;

[ConnectionStringName(StoreServiceDbProperties.ConnectionStringName)]
public class StoreServiceDbContext : AbpDbContext<StoreServiceDbContext>
{

    public StoreServiceDbContext(DbContextOptions<StoreServiceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureStoreService();
    }
}
