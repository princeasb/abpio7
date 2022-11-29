using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.Shared.Hosting;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpDataModule)
)]
public class SchoolAut0materSharedHostingModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureDatabaseConnections();
    }

    private void ConfigureDatabaseConnections()
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.Databases.Configure("SaasService", database =>
            {
                database.MappedConnections.Add("Saas");
                database.IsUsedByTenants = false;
            });

            options.Databases.Configure("AdministrationService", database =>
            {
                database.MappedConnections.Add("AbpAuditLogging");
                database.MappedConnections.Add("AbpPermissionManagement");
                database.MappedConnections.Add("AbpSettingManagement");
                database.MappedConnections.Add("AbpFeatureManagement");
                database.MappedConnections.Add("AbpLanguageManagement");
                database.MappedConnections.Add("TextTemplateManagement");
                database.MappedConnections.Add("AbpBlobStoring");
            });

            options.Databases.Configure("IdentityService", database =>
            {
                database.MappedConnections.Add("AbpIdentity");
                database.MappedConnections.Add("OpenIddict");
            });

            options.Databases.Configure("CoreService", database =>
            {
                database.MappedConnections.Add("CoreService");
            });

            options.Databases.Configure("ProductService", database =>
            {
                database.MappedConnections.Add("ProductService");
            });
        });
    }
}
