using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.StoreService.EntityFrameworkCore;

[DependsOn(
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpEntityFrameworkCoreModule),
    typeof(StoreServiceDomainModule)
)]
public class StoreServiceEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        StoreServiceEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<StoreServiceDbContext>(options =>
        {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure<StoreServiceDbContext>(c =>
            {
                c.UseSqlServer(b =>
                {
                    b.MigrationsHistoryTable("__StoreService_Migrations");
                });
            });
        });
    }
}
