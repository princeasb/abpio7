using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace SchoolAut0mater.PowerSchoolService;

[DependsOn(
    typeof(PowerSchoolServiceApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class PowerSchoolServiceHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(typeof(PowerSchoolServiceApplicationContractsModule).Assembly,
            PowerSchoolServiceRemoteServiceConsts.RemoteServiceName);

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<PowerSchoolServiceHttpApiClientModule>();
        });
    }
}
