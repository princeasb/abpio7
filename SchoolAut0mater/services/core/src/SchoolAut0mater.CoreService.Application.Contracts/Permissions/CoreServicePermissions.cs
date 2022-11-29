using Volo.Abp.Reflection;

namespace SchoolAut0mater.CoreService.Permissions;

public class CoreServicePermissions
{
    public const string GroupName = "CoreService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(CoreServicePermissions));
    }

    public static class MITCatalogs
    {
        public const string Default = GroupName + ".MITCatalogs";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}