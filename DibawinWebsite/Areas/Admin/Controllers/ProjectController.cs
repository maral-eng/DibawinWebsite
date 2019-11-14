using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DibawinWebsite.Areas.Identity.Data;
using DibawinWebsite.ClassLibraries.MenuGenrator.Attributes;
using DibawinWebsite.ClassLibraries.NotificationHandler;
using DibawinWebsite.Models.AdminViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DibawinWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperVisor")]
    [MenuItem(Title ="پروژه ها", CssIcon = "ion ion-cube")]
    public class ProjectController : Controller
    {
        #region Inject
        private readonly IHostingEnvironment _hostingEnvironment;
        readonly string contentRootPath;
        UserManager<ApplicationUser> _userManager;

        public ProjectController
            (
                IHostingEnvironment hostingEnvironment,
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager
            )
        {
            _hostingEnvironment = hostingEnvironment;
            contentRootPath = _hostingEnvironment.ContentRootPath;//returns the root path of the website
            _userManager = userManager;

        }
        #endregion

        #region Projects
        [MenuItem(Title = "ثبت پروژه")]
        public ViewResult AddProject(string notification)
        {
            if (notification != null)
            {
                ViewData["nvm"] = NotificationHandler.DeserializeMessage(notification);
                return View();
            }
            return View();
        }

        public async Task<IActionResult> AddConfirm(ProjectClientViewModel model)
        {
            //string nvm;
            //if (!ModelState.IsValid)
            //{
            //    nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Wrong_Values, contentRootPath);
            //    return RedirectToAction("Add", new { notification = nvm });
            //}
            return RedirectToAction("Add");
        }

        [MenuItem(Title = "لیست پروژه ها")]
        public ViewResult List()
        {
            return View();
        }
        #endregion

        #region Category
        [MenuItem(Title = "افزودن دسته بندی")]
        public ViewResult AddCategory()
        {
            return View();
        }
        public async Task<IActionResult> AddCategoryConfirm(CategoryViewModel model)
        {
            //string nvm;
            //if (!ModelState.IsValid)
            //{
            //    nvm = NotificationHandler.SerializeMessage<string>(NotificationHandler.Wrong_Values, contentRootPath);
            //    return RedirectToAction("Add", new { notification = nvm });
            //}
            return RedirectToAction("Add");
        }

        #endregion
    }
}