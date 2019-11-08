using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DibawinWebsite.ClassLibraries.NotificationHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DibawinWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperVisor")]
    public class HomeController : Controller
    {
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