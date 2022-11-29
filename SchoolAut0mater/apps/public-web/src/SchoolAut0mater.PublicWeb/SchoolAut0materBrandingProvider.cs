using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace SchoolAut0mater.PublicWeb;

[Dependency(ReplaceServices = true)]
public class SchoolAut0materBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SchoolAut0mater";
}
