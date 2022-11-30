using SchoolAut0mater.CoreService.Localization;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Validation.StringValues;

namespace SchoolAut0mater.CoreService.Features
{
    public class CoreServiceFeatureDefinitionProvider : Volo.Abp.Features.FeatureDefinitionProvider
    {
        public override void Define(IFeatureDefinitionContext context)
        {
            var coreServiceFeatureGroup = context.AddGroup(
                CoreServiceFeatures.ConcurrentUser.GroupName,
                L("Feature:CoreService")
            );

            var coreSettingManagementEnableFeature = coreServiceFeatureGroup.AddFeature(
                CoreServiceFeatures.ConcurrentUser.Enable,
                defaultValue: "false",
                displayName: L("Feature:CoreServiceConcurrentUserEnable"),
                description: L("Feature:CoreServiceConcurrentUserDescription"),
                valueType: new ToggleStringValueType()
            );
            coreSettingManagementEnableFeature.IsAvailableToHost = false;

            coreSettingManagementEnableFeature.CreateChild(
                CoreServiceFeatures.ConcurrentUser.AllowTenantsToChangeCoreServiceSettings,
                defaultValue: "false",
                displayName: L("Feature:AllowTenantsToChangeCoreServiceSettings"),
                description: L("AllowTenantsToChangeCoreServiceSettings"),
                valueType: new ToggleStringValueType(),
                isAvailableToHost: false,
                isVisibleToClients: true
            );
        }

        private ILocalizableString L(string name) => LocalizableString.Create<CoreServiceResource>(name);
    }
}
