using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace SchoolAut0mater.StoreService;

[DependsOn(
    typeof(StoreServiceApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class StoreServiceHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(typeof(StoreServiceApplicationContractsModule).Assembly,
            StoreServiceRemoteServiceConsts.RemoteServiceName);

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<StoreServiceHttpApiClientModule>();
        });
    }
}
