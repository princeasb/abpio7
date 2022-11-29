using Volo.Abp.Modularity;
using Volo.Saas;
using Volo.Payment;

namespace SchoolAut0mater.SaasService;

[DependsOn(
    typeof(SaasServiceDomainSharedModule),
    typeof(SaasDomainModule),
    typeof(AbpPaymentDomainModule)
)]
public class SaasServiceDomainModule : AbpModule
{
}
