using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace SchoolAut0mater.CoreService;

[DependsOn(
    typeof(CoreServiceApplicationContractsModule),
    typeof(AbpHttpClientModule)
)]
public class CoreServiceHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(CoreServiceApplicationContractsModule).Assembly,
            CoreServiceRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CoreServiceHttpApiClientModule>();
        });
    }
}
