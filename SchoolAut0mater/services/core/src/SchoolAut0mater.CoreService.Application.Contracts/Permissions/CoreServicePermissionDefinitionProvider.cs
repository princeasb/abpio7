using SchoolAut0mater.CoreService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace SchoolAut0mater.CoreService.Permissions;

public class CoreServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var coreServiceGroup = context.AddGroup(
            CoreServicePermissions.GroupName,
            displayName: L("Permission:CoreService")
        );

        //Define your own permissions here. Example:
        //myGroup.AddPermission(BookStorePermissions.MyPermission1, L("Permission:MyPermission1"));

        coreServiceGroup.AddPermission(
            CoreServicePermissions.Settings.Default,
            displayName: L("Permission:CoreServiceSettings"),
            multiTenancySide: MultiTenancySides.Tenant
        ).StateCheckers.Add(new Features.AllowTenantsToChangeCoreServiceSettingsFeatureSimpleStateChecker());

        var mITCatalogPermission = coreServiceGroup.AddPermission(CoreServicePermissions.MITCatalogs.Default, L("Permission:MITCatalogs"));
        mITCatalogPermission.AddChild(CoreServicePermissions.MITCatalogs.Create, L("Permission:Create"));
        mITCatalogPermission.AddChild(CoreServicePermissions.MITCatalogs.Edit, L("Permission:Edit"));
        mITCatalogPermission.AddChild(CoreServicePermissions.MITCatalogs.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name) => LocalizableString.Create<CoreServiceResource>(name);
}