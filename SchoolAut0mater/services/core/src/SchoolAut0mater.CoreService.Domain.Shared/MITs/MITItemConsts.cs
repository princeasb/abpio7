namespace SchoolAut0mater.CoreService.MITs
{
    public static class MITItemConsts
    {
        private const string DefaultSorting = "{0}MITCatalogId asc,{0}SortOrder asc";

        public static string GetDefaultSorting(bool withEntityName) => string.Format(DefaultSorting, withEntityName ? "MITItem." : string.Empty);


        public const int CodeMinLength = 2;
        public const int CodeMaxLength = 20;
        public const int NameMinLength = 2;
        public const int NameMaxLength = 100;
        public const int DatabaseValueMinLength = 1;
        public const int DatabaseValueMaxLength = 50;
        public const int DisplayValueMinLength = 1;
        public const int DisplayValueMaxLength = 50;
    }
}