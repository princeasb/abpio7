using Volo.Abp.Reflection;

namespace SchoolAut0mater.StaffService.Permissions;

public class StaffServicePermissions
{
    public const string GroupName = "StaffService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(StaffServicePermissions));
    }
}
