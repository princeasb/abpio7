using SchoolAut0mater.AdministrationService;
using SchoolAut0mater.AdministrationService.EntityFrameworkCore;
using SchoolAut0mater.IdentityService;
using SchoolAut0mater.IdentityService.EntityFrameworkCore;
using SchoolAut0mater.CoreService;
using SchoolAut0mater.CoreService.EntityFrameworkCore;
using SchoolAut0mater.StaffService;
using SchoolAut0mater.StaffService.EntityFrameworkCore;
using SchoolAut0mater.ProductService;
using SchoolAut0mater.ProductService.EntityFrameworkCore;
using SchoolAut0mater.SaasService;
using SchoolAut0mater.SaasService.EntityFrameworkCore;
using SchoolAut0mater.Shared.Hosting;
using Volo.Abp.Modularity;

namespace SchoolAut0mater.DbMigrator;

[DependsOn(
    typeof(SchoolAut0materSharedHostingModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(SaasServiceEntityFrameworkCoreModule),
    typeof(SaasServiceApplicationContractsModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(CoreServiceApplicationContractsModule),
    typeof(CoreServiceEntityFrameworkCoreModule),
    typeof(StaffServiceApplicationContractsModule),
    typeof(StaffServiceEntityFrameworkCoreModule),
    typeof(ProductServiceApplicationContractsModule),
    typeof(ProductServiceEntityFrameworkCoreModule)
)]
public class SchoolAut0materDbMigratorModule : AbpModule
{

}
