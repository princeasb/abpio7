using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace SchoolAut0mater.AuthServer.Pages;

public class IndexModel : AbpPageModel
{
    public ActionResult OnGet()
    {
        if (!CurrentUser.IsAuthenticated)
        {
            return Redirect("~/Account/Login");
        }
        else
        {
            return Page();
        }
    }
}
