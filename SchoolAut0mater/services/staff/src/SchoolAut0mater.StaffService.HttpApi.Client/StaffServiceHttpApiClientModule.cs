using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace SchoolAut0mater.StaffService;

[DependsOn(
    typeof(StaffServiceApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class StaffServiceHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(typeof(StaffServiceApplicationContractsModule).Assembly,
            StaffServiceRemoteServiceConsts.RemoteServiceName);

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<StaffServiceHttpApiClientModule>();
        });
    }
}
