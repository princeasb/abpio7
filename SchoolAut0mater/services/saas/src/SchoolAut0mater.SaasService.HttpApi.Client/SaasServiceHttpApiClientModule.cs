﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Saas.Host;
using Volo.Saas.Tenant;
using Volo.Payment.Admin;

namespace SchoolAut0mater.SaasService;

[DependsOn(
    typeof(SaasServiceApplicationContractsModule),
    typeof(SaasTenantHttpApiClientModule),
    typeof(SaasHostHttpApiClientModule),
    typeof(AbpPaymentAdminHttpApiClientModule)
)]
public class SaasServiceHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(SaasServiceApplicationContractsModule).Assembly,
            SaasServiceRemoteServiceConsts.RemoteServiceName
        );
    }
}
