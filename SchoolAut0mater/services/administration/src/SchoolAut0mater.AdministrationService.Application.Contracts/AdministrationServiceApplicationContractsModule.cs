﻿using Volo.Abp.AuditLogging;
using Volo.Abp.FeatureManagement;
using Volo.Abp.LanguageManagement;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TextTemplateManagement;

namespace SchoolAut0mater.AdministrationService;

[DependsOn(
    typeof(AbpPermissionManagementApplicationContractsModule),
    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpAuditLoggingApplicationContractsModule),
    typeof(LanguageManagementApplicationContractsModule),
    typeof(TextTemplateManagementApplicationContractsModule),
    typeof(AdministrationServiceDomainSharedModule)
)]
public class AdministrationServiceApplicationContractsModule : AbpModule
{
}
