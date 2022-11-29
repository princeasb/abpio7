using Volo.Abp.Reflection;

namespace SchoolAut0mater.StoreService.Permissions;

public class StoreServicePermissions
{
    public const string GroupName = "StoreService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(StoreServicePermissions));
    }
}
