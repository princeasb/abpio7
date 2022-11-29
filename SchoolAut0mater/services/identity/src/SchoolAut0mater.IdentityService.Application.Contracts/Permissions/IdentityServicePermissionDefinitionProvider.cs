using SchoolAut0mater.IdentityService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SchoolAut0mater.IdentityService.Permissions;

public class IdentityServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(IdentityServicePermissions.GroupName, L("Permission:IdentityService"));

        //Define your own permissions here. Example:
        //myGroup.AddPermission(BookStorePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<IdentityServiceResource>(name);
    }
}
