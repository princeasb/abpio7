using SchoolAut0mater.StoreService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SchoolAut0mater.StoreService.Permissions;

public class StoreServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(StoreServicePermissions.GroupName, L("Permission:StoreService"));

        //Define your own permissions here. Example:
        //myGroup.AddPermission(BookStorePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<StoreServiceResource>(name);
    }
}
