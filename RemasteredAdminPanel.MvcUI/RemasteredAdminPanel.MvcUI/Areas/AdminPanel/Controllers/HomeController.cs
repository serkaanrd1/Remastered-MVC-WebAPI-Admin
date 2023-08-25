using RemasteredPanel.MvcUI.Areas.AdminPanel.Filters;
using Microsoft.AspNetCore.Mvc;

namespace RemasteredPanel.MvcUI.Areas.AdminPanel.Controllers
{
  [Area("AdminPanel")]
  [SessionControlAspect]
  public class HomeController : Controller
  {
    [LogAspect]
    public IActionResult Index()
    {
      return View();
    }


  }
}
