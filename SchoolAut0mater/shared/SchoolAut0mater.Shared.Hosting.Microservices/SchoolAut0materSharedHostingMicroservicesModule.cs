using Medallion.Threading;
using Medallion.Threading.Redis;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using SchoolAut0mater.AdministrationService.EntityFrameworkCore;
using SchoolAut0mater.SaasService.EntityFrameworkCore;
using SchoolAut0mater.Shared.Hosting.AspNetCore;
using StackExchange.Redis;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.BackgroundJobs.RabbitMQ;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Modularity;
// using Volo.Abp.MongoDB;
using Volo.Abp.MultiTenancy;

namespace SchoolAut0mater.Shared.Hosting.Microservices;

[DependsOn(
    // typeof(AbpMongoDbModule), // Un-comment if you are using mongodb in any microservice
    typeof(SchoolAut0materSharedHostingAspNetCoreModule),
    typeof(AbpBackgroundJobsRabbitMqModule),
    typeof(AbpAspNetCoreMultiTenancyModule),
    typeof(AbpDistributedLockingModule),
    typeof(AbpEventBusRabbitMqModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(SaasServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule)
)]
public class SchoolAut0materSharedHostingMicroservicesModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = true;
        });

        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.KeyPrefix = "SchoolAut0mater:";
        });

        var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);

        context.Services
            .AddDataProtection()
            .SetApplicationName("SchoolAut0mater")
            .PersistKeysToStackExchangeRedis(redis, "SchoolAut0mater-Protection-Keys");

        context.Services.AddSingleton<IDistributedLockProvider>(_ =>
            new RedisDistributedSynchronizationProvider(redis.GetDatabase()));
    }
}