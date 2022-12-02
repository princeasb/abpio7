using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SchoolAut0mater.CoreService.MITs;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace SchoolAut0mater.CoreService.EntityFrameworkCore;

public class CoreServiceDataSeeder : ITransientDependency
{
    //private readonly IApiResourceRepository _apiResourceRepository;
    //private readonly IApiScopeRepository _apiScopeRepository;
    //private readonly IClientRepository _clientRepository;
    //private readonly IIdentityResourceDataSeeder _identityResourceDataSeeder;
    //private readonly IPermissionDataSeeder _permissionDataSeeder;
    private readonly IGuidGenerator _guidGenerator;
    private readonly IConfiguration _configuration;
    private readonly ICurrentTenant _currentTenant;
    private readonly IRepository<MITCatalog, int> _mitCatalogRepository;
    //private readonly IRepository<MITItem, int> _mitItemRepository;
    private readonly ILogger<CoreServiceDataSeeder> _logger;

    public CoreServiceDataSeeder(
        //IClientRepository clientRepository,
        //IApiResourceRepository apiResourceRepository,
        //IApiScopeRepository apiScopeRepository,
        //IIdentityResourceDataSeeder identityResourceDataSeeder,
        //IPermissionDataSeeder permissionDataSeeder,
        IRepository<MITCatalog, int> mitCatalogRepository,
        // IRepository<MITItem, int> mitItemRepository,
        IGuidGenerator guidGenerator,
        IConfiguration configuration,
        ICurrentTenant currentTenant,
        ILogger<CoreServiceDataSeeder> logger
    )
    {
        //_clientRepository = clientRepository;
        //_apiResourceRepository = apiResourceRepository;
        //_apiScopeRepository = apiScopeRepository;
        //_identityResourceDataSeeder = identityResourceDataSeeder;
        //_permissionDataSeeder = permissionDataSeeder;
        _mitCatalogRepository = mitCatalogRepository;
        // _mitItemRepository = mitItemRepository;
        _guidGenerator = guidGenerator;
        _configuration = configuration;
        _currentTenant = currentTenant;
        //Logger = NullLogger<CoreServiceDataSeeder>.Instance;
        _logger = logger;
    }

    [UnitOfWork]
    public virtual async Task SeedAsync(DataSeedContext context)
    {
        _logger.LogInformation("*******************************************");
        _logger.LogInformation("********** CoreServiceDataSeeder **********");
        _logger.LogInformation("*******************************************");

        using (_currentTenant.Change(null))
        {
            int mitId = new();
            mitId = await AddCatalogIfNotExists(CatalogNames.YesNo, "Yes No");
            /*
            await AddItemIfNotExistsForFactory(mitId, "Yes", "Yes", "Y", "Yes", sortOrder: 1);
            await AddItemIfNotExistsForFactory(mitId, "No", "No", "N", "No", sortOrder: 2);
            await AddItemIfNotExistsForFactory(mitId, "MayBe", "May Be", "M", "May Be");
            mitId = default;

            //Gender
            mitId = new();
            mitId = await AddCatalogIfNotExists(CatalogNames.Gender, CatalogNames.Gender.FromPascalCase());
            await AddItemIfNotExistsForFactory(mitId, "Male", "Male", "Male", sortOrder: 1);
            await AddItemIfNotExistsForFactory(mitId, "Female", "Female", "Female", sortOrder: 2);
            await AddItemIfNotExistsForFactory(mitId, "ND", "Not Declared", "ND", "Not Declared");
            mitId = default;

            //Nationality
            mitId = await AddCatalogIfNotExists(CatalogNames.Nationality, CatalogNames.Nationality.FromPascalCase());
            // try
            // {
            //     List<CSVCountry> countries = default;
            //     string resourceName = "SchoolAut0mater.Migrations.Seed.SeedData.countries.csv";
            //     var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture);
            //     using (Stream stream = this.GetType().Assembly.GetManifestResourceStream(resourceName))
            //     using (var reader = new StreamReader(stream, Encoding.UTF8))
            //     using (var csv = new CsvReader(reader, csvConfiguration)) countries = csv.GetRecords<CSVCountry>().ToList();
            //     foreach (var csv in countries) AddItemIfNotExists(mitid, csv.code.ToUpperInvariant().Trim(), csv.name.Trim(), csv.code.ToUpperInvariant().Trim(), csv.name.Trim());
            // }
            // catch { }
            mitId = new();

            mitId = await AddCatalogIfNotExists(CatalogNames.Currency, CatalogNames.Currency.FromPascalCase());
            await AddItemIfNotExistsForFactory(mitId, "AED", "UAE Dirham", "AED", "AED");
            await AddItemIfNotExistsForFactory(mitId, "BBD", "Barbados Dollar", "BBD", "BBD");
            await AddItemIfNotExistsForFactory(mitId, "BHD", "Bahraini Dinar", "BHD", "BHD");
            await AddItemIfNotExistsForFactory(mitId, "BYN", "Belarusian Ruble", "BYN", "BYN");
            await AddItemIfNotExistsForFactory(mitId, "CAD", "Canadian Dollar", "CAD", "CAD");
            await AddItemIfNotExistsForFactory(mitId, "EUR", "Euro", "EUR", "EUR");
            await AddItemIfNotExistsForFactory(mitId, "GBP", "Pound Sterling", "GBP", "GBP");
            await AddItemIfNotExistsForFactory(mitId, "INR", "Indian Rupee", "INR", "INR");
            await AddItemIfNotExistsForFactory(mitId, "JPY", "Yen", "JPY", "JPY");
            await AddItemIfNotExistsForFactory(mitId, "NZD", "New Zealand Dollar", "NZD", "NZD");
            await AddItemIfNotExistsForFactory(mitId, "QAR", "Qatari Rial", "QAR", "QAR");
            await AddItemIfNotExistsForFactory(mitId, "SAR", "Saudi Riyal", "SAR", "SAR");
            await AddItemIfNotExistsForFactory(mitId, "SGD", "Singapore Dollar", "SGD", "SGD");
            await AddItemIfNotExistsForFactory(mitId, "USD", "US Dollar", "USD", "USD");
            mitId = default;

            await AddCatalogIfNotExists(CatalogNames.Store.ItemCategory, "Store > Item > Category", MITCatalogControlTypes.Select, false, features: FeatureNames.Store.StoreManagementFeature.Split(','));
            await AddCatalogIfNotExists(CatalogNames.Store.ItemBrand, "Store > Item > Brand", MITCatalogControlTypes.Select, false, features: FeatureNames.Store.StoreManagementFeature.Split(','));
            await AddCatalogIfNotExists(CatalogNames.Store.ItemModel, "Store > Item > Brand > Model", MITCatalogControlTypes.Select, false, CatalogNames.Store.ItemBrand, features: FeatureNames.Store.StoreManagementFeature.Split(','));

            // var tenants = await TenantRepository.GetListAsync();
            // foreach(var tenant in tenants)
            // {
            //     using(CurrentTenant.Change(tenant.Id))
            //     {
            //         //inserts/updates for a tenant here..
            //     }
            // }
            */
        }
        await Task.CompletedTask;
    }

    private async Task<int> AddCatalogIfNotExists(
        string code,
        string name,
        bool isFactory = true,
        List<string> features = default(List<string>),
        string parentCode = default(string)
    )
    {
        var _catalog = await _mitCatalogRepository.FirstOrDefaultAsync(s => s.Code == code);
        if (_catalog == null)
        {
            _catalog = new MITCatalog(
                code,
                name,
                linkedFeatures: features ?? new List<string> { "*" },
                isFactory: isFactory
            );

            if (!string.IsNullOrWhiteSpace(parentCode)) { _catalog.ParentCatalogCode = parentCode; }
            _logger.LogInformation("DataSeeding for MITCatalog {0}", Newtonsoft.Json.JsonConvert.SerializeObject(_catalog));
            _catalog = await _mitCatalogRepository.InsertAsync(_catalog);
        }
        if (_catalog == null) { throw new Exception($"Error in Creation of MIT Category => {Newtonsoft.Json.JsonConvert.SerializeObject(_catalog)}"); }
        return await Task.FromResult(_catalog.Id);
    }

    /*
    private async Task AddItemIfNotExistsForFactory(
        int masterid, string code,
        string name, string databaseValue,
        string displayValue = default,
        string description = default,
        //bool isFactory = true,
        int sortOrder = 999
    )
    {
        if (masterid == 0) return;
        if (string.IsNullOrEmpty(displayValue)) { displayValue = databaseValue; }
        var mit = await _mitCatalogRepository.FindAsync(masterid);

        //if (mit.IsFactory) {
        if (await _mitItemRepository.AnyAsync(s => s.CatalogId == masterid && (s.Code == code || s.Name == name))) return;

        _logger.LogInformation("DataSeeding for MITItem {0} => {1}", masterid, code);//, Newtonsoft.Json.JsonConvert.SerializeObject(_catalog));

        MITItem dit;
        dit = new MITItem(
            masterid,
            code,
            name,
            databaseValue,
            displayValue,
            description: description,
            sortOrder: sortOrder,
            isFactory: true,
            isActive: true
        );
        await _mitItemRepository.InsertAsync(dit);
        / *
        }
        else
        {
            //foreach (var tenant in _context.Tenants.IgnoreQueryFilters().Where(t => t.IsActive && !t.IsDeleted && t.TenancyName != "Default").ToList())
            MITItem dit;
            if (isFactory)
            {
                if (_context.MITItems.IgnoreQueryFilters().Any(s => s.CatalogId == masterid && (s.Code == code || s.Name == name))) return;
                dit = MITItem.Create(masterid, code, name, databaseValue, displayValue);
                dit.Description = description;
                dit.IsActive = true;
                dit.IsFactory = isFactory;
                dit.SortOrder = sortOrder;
                _context.MITItems.Add(dit);
            }
            else
            {
                foreach (var tenant in _context.Tenants.IgnoreQueryFilters().Where(t => t.IsActive && !t.IsDeleted).ToList())
                {
                    if (_context.MITItems.IgnoreQueryFilters().Any(s => s.TenantId.GetValueOrDefault() == tenant.Id && s.CatalogId == masterid && (s.Code == code || s.Name == name))) continue;
                    dit = MITItem.Create(masterid, code, name, databaseValue, displayValue, tenantId: tenant.Id);
                    dit.Description = description;
                    dit.IsActive = true;
                    dit.IsFactory = isFactory;
                    dit.SortOrder = sortOrder;
                    _context.MITItems.Add(dit);
                }
            }
            _context.SaveChanges();
        }
        * /
    }
    */
}
