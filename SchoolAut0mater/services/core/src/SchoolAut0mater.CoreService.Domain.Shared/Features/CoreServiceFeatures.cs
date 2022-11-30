namespace SchoolAut0mater.CoreService.Features
{
    public class CoreServiceFeatures
    {
        private const string CoreService = "CoreService";

        public static class ConcurrentUser
        {
            public const string GroupName = CoreService + ".ConcurrentUser";
            public const string Enable = GroupName + ".Enable";
            public const string AllowTenantsToChangeCoreServiceSettings = GroupName + ".AllowTenantsToChangeCoreServiceSettings";
        }

        // public const string GroupName = CoreService+".CoreService";
        // public static class User
        // {
        //     public const string MaxUserCount = "MaxUserCount";
        //     public const string MaxUserCountReached = "MaxUserCountReached";
        //     public const string FeatureMaxUserCount = GroupName + "." + MaxUserCount;
        //     public const string SettingConcurrentUser = GroupName + ".ConcurrentUser";
        // }
    }
}
