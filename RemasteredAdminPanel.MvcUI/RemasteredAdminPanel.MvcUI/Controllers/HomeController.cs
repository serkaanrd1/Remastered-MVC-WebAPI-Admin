using Microsoft.AspNetCore.Mvc;
using RemasteredAdminPanel.MvcUI.Models;
using System.Diagnostics;

namespace RemasteredAdminPanel.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}