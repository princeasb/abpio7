using SchoolAut0mater.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace SchoolAut0mater;

[DependsOn(
    typeof(AbpValidationModule)
    )]
public class SchoolAut0materSharedLocalizationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SchoolAut0materSharedLocalizationModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<SchoolAut0materResource>("en")
                .AddBaseTypes(
                    typeof(AbpValidationResource)
                ).AddVirtualJson("/Localization/SchoolAut0mater");

            options.DefaultResourceType = typeof(SchoolAut0materResource);
        });
    }
}
