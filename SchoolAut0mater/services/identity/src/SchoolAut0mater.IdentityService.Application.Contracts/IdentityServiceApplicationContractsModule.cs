﻿using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict;

namespace SchoolAut0mater.IdentityService;

[DependsOn(
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpOpenIddictProApplicationContractsModule),
    typeof(AbpAccountAdminApplicationContractsModule),
    typeof(IdentityServiceDomainSharedModule)
)]
public class IdentityServiceApplicationContractsModule : AbpModule
{
}
