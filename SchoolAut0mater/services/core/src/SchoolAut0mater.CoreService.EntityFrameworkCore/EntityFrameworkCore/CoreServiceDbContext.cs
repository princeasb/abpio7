using SchoolAut0mater.CoreService.MITs;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using System.Reflection.Emit;

namespace SchoolAut0mater.CoreService.EntityFrameworkCore;

[ConnectionStringName(CoreServiceDbProperties.ConnectionStringName)]
public class CoreServiceDbContext : AbpDbContext<CoreServiceDbContext>
{
    public DbSet<MITCatalog> MITCatalogs { get; set; }

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