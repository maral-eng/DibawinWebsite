using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DibawinWebsite.ClassLibraries.MenuGenrator.Attributes;
using DibawinWebsite.ClassLibraries.NotificationHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DibawinWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperVisor")]
    [MenuItem(Action = "Index", Title = "داشبورد", CssIcon = "fa fa-dashboard", Order = 1)]
    public class HomeController : Controller
    {
        [MenuItem(Title ="داشبورد")]
        public IActionResult Index(string notification)
        {
            if (notification != null)
            {
                ViewData["nvm"] = NotificationHandler.DeserializeMessage(notification);
                return View();
            }
            return View();
        }
    }
}