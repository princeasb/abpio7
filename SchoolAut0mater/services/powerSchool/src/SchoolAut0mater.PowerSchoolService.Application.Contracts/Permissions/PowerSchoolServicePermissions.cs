using Volo.Abp.Reflection;

namespace SchoolAut0mater.PowerSchoolService.Permissions;

public class PowerSchoolServicePermissions
{
    public const string GroupName = "PowerSchoolService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(PowerSchoolServicePermissions));
    }
}
