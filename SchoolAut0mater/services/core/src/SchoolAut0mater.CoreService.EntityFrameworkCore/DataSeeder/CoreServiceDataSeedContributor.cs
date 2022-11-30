//using Microsoft.Extensions.Logging;
//using System.Threading.Tasks;
//using Volo.Abp.Data;
//using Volo.Abp.DependencyInjection;

//namespace SchoolAut0mater.CoreService.EntityFrameworkCore;

//public class CoreServiceDataSeedContributor : IDataSeedContributor, ITransientDependency
//{
//    private readonly CoreService.EntityFrameworkCore.CoreServiceDataSeeder _coreServiceDataSeeder;
//    private readonly ILogger<CoreServiceDataSeedContributor> _logger;

//    public CoreServiceDataSeedContributor(
//        CoreService.EntityFrameworkCore.CoreServiceDataSeeder coreServiceDataSeeder,
//        ILogger<CoreServiceDataSeedContributor> logger
//    )
//    {
//        _coreServiceDataSeeder = coreServiceDataSeeder;
//        _logger = logger;
//    }

//    public async Task SeedAsync(DataSeedContext context)
//    {
//        _logger.LogInformation($"Seeding Core Service");
//        //await _coreServiceDataSeeder.SeedAsync(context);
//    }
//}
