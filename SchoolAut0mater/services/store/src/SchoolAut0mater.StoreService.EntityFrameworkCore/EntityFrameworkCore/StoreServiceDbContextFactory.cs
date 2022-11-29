using System.IO;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Volo.Abp;

namespace SchoolAut0mater.StoreService.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands)
 *
 * It is also used in the DbMigrator application.
 * */
public class StoreServiceDbContextFactory : IDesignTimeDbContextFactory<StoreServiceDbContext>
{
    private readonly string _connectionString;

    /* This constructor is used when you use EF Core tooling (e.g. Update-Database) */
    public StoreServiceDbContextFactory()
    {
        _connectionString = GetConnectionStringFromConfiguration();
    }

    /* This constructor is used by DbMigrator application */
    public StoreServiceDbContextFactory([NotNull] string connectionString)
    {
        Check.NotNullOrWhiteSpace(connectionString, nameof(connectionString));
        _connectionString = connectionString;
    }

    public StoreServiceDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<StoreServiceDbContext>()
            .UseSqlServer(_connectionString, b =>
            {
                b.MigrationsHistoryTable("__StoreService_Migrations");
            });

        return new StoreServiceDbContext(builder.Options);
    }

    private static string GetConnectionStringFromConfiguration()
    {
        return BuildConfiguration()
            .GetConnectionString(StoreServiceDbProperties.ConnectionStringName);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    $"..{Path.DirectorySeparatorChar}SchoolAut0mater.StoreService.HttpApi.Host"
                )
            )
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
