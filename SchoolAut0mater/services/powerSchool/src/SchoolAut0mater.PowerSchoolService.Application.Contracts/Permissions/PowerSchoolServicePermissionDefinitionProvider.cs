using SchoolAut0mater.PowerSchoolService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SchoolAut0mater.PowerSchoolService.Permissions;

public class PowerSchoolServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PowerSchoolServicePermissions.GroupName, L("Permission:PowerSchoolService"));

        //Define your own permissions here. Example:
        //myGroup.AddPermission(BookStorePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PowerSchoolServiceResource>(name);
    }
}
