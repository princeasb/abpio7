//using SchoolAut0mater.CoreService.Localization;
//using Volo.Abp.Localization;
//using Volo.Abp.Settings;

//namespace SchoolAut0mater.CoreService.Settings;

//public class CoreServiceServiceSettingDefinitionProvider : SettingDefinitionProvider
//{
//    public override void Define(ISettingDefinitionContext context)
//    {
//        /* Define module settings here.
//         * Use names from CoreServiceSettings class.
//         */
//        context.Add(
//            new SettingDefinition(
//                Settings.CoreServiceSettings.AllowConCurrentUsers,
//                displayName: L("Settings:AllowConCurrentUsers"),
//                defaultValue: "true",
//                isVisibleToClients: true
//            )
//        );
//    }
//    private ILocalizableString L(string name) => LocalizableString.Create<CoreServiceResource>(name);
//}
