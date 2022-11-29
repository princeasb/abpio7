namespace SchoolAut0mater.CoreService.MITs
{
    public static class MITCatalogConsts
    {
        private const string DefaultSorting = "{0}LinkedFeatures asc,{0}ParentCatalogCode asc,{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "MITCatalog." : string.Empty);
        }

        public const int ParentCatalogCodeMaxLength = 20;
        public const int CodeMinLength = 3;
        public const int CodeMaxLength = 20;
        public const int NameMinLength = 3;
        public const int NameMaxLength = 100;
        public const int LinkedFeaturesMinLength = 0;
        public const int LinkedFeaturesMaxLength = 250;
    }
}