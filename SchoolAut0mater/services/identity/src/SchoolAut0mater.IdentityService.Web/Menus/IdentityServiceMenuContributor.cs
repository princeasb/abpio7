using System.Threading.Tasks;
using SchoolAut0mater.IdentityService.Localization;
using Volo.Abp.UI.Navigation;

namespace SchoolAut0mater.IdentityService.Web.Menus;

public class IdentityServiceMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<IdentityServiceResource>();
        return Task.CompletedTask;
    }
}
