using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DibawinWebsite.Controllers
{
    public class PageController : Controller
    {
        #region Index
        public IActionResult Index()
        {
            return RedirectToAction("About");
        }
        #endregion
        #region About
        public IActionResult About()
        {
            return View();
        }
        #endregion
        #region ContactUs
        public IActionResult ContactUs()
        {
            return View();
        }
        #endregion

    }
}