namespace SchoolAut0mater.CoreService.Shared
{
    public class MITLookupDto<TKey> : LookupDto<TKey>
    {
        public string Code { get; set; }
        public string DisplayValue { get; set; }
        public string DatabaseValue { get; set; }
    }
}