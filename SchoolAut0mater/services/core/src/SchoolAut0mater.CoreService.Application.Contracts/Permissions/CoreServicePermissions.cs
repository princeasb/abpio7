using Volo.Abp.Reflection;

namespace SchoolAut0mater.CoreService.Permissions;

public class CoreServicePermissions
{
    public const string GroupName = "CoreService";

    public static string[] GetAll() => ReflectionHelper.GetPublicConstantsRecursively(typeof(CoreServicePermissions));

    public static class Dashboard
    {
        public const string DashboardGroup = GroupName + ".Dashboard";
        public const string Host = DashboardGroup + ".Host";
        public const string Tenant = GroupName + ".Tenant";
    }

    public static class Settings
    {
        public const string Default = GroupName + ".SettingManagement";
    }

    public static class MITCatalogs
    {
        public const string Default = GroupName + ".MITCatalogs";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}