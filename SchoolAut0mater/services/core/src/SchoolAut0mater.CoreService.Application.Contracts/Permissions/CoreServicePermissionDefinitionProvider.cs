using SchoolAut0mater.CoreService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SchoolAut0mater.CoreService.Permissions;

public class CoreServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CoreServicePermissions.GroupName, L("Permission:CoreService"));

        //Define your own permissions here. Example:
        //myGroup.AddPermission(BookStorePermissions.MyPermission1, L("Permission:MyPermission1"));

        var mITCatalogPermission = myGroup.AddPermission(CoreServicePermissions.MITCatalogs.Default, L("Permission:MITCatalogs"));
        mITCatalogPermission.AddChild(CoreServicePermissions.MITCatalogs.Create, L("Permission:Create"));
        mITCatalogPermission.AddChild(CoreServicePermissions.MITCatalogs.Edit, L("Permission:Edit"));
        mITCatalogPermission.AddChild(CoreServicePermissions.MITCatalogs.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CoreServiceResource>(name);
    }
}