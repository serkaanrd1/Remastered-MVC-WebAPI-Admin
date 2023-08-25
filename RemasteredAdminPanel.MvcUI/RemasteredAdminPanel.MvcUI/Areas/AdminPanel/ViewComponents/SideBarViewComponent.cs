using RemasteredPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace RemasteredPanel.MvcUI.Areas.AdminPanel.ViewComponents
{
  public class SideBarViewComponent:ViewComponent
  {
    // Bu component içindeki metodun adı Invoke olmak zorundadır. 
    public IViewComponentResult Invoke()
    {
      var sessionData = HttpContext.Session.GetString("ActiveAdminPanelUser");
      var admin = JsonSerializer.Deserialize<AdminPanelUserItem>(sessionData);

      return View(admin);
    }
  }
}
