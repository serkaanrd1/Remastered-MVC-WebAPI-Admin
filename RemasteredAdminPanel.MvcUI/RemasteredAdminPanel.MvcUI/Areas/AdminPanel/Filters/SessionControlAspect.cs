using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RemasteredPanel.MvcUI.Areas.AdminPanel.Filters
{
  public class SessionControlAspect:ActionFilterAttribute
  {
    // metod ilk tetiklendiğinde session ı kontrol etsin
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      var sessionData = context.HttpContext.Session.GetString("ActiveAdminPanelUser");

      if (string.IsNullOrEmpty(sessionData))
        context.Result = new RedirectToActionResult("LogIn", "Authentication", null);
      
    }
  }
}
