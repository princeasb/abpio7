using Volo.Abp.Reflection;

namespace SchoolAut0mater.CoreService.Permissions;

public class CoreServicePermissions
{
    public const string GroupName = "CoreService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(CoreServicePermissions));
    }
}
