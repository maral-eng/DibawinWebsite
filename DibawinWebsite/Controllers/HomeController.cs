using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DibawinWebsite.Models;
using DibawinWebsite.Areas.Identity.Data;
using DibawinWebsite.ClassLibraries;
using DibawinWebsite.ClassLibraries.Authentication;
using DibawinWebsite.Models.ViewModels;
using DibawinWebsite.Repository;

namespace DibawinWebsite.Controllers
{
    public class HomeController : Controller
    {
        #region Inject
        //Inject DataBase--Start
        UserManager<ApplicationUser> userManager;
        DbRepository<MyDBContext, ContactUs, int> dbContactUs;
        public HomeController
            (
                UserManager<ApplicationUser> _userManager,
                DbRepository<MyDBContext, ContactUs, int> _dbContactUs
            )
        {
            userManager = _userManager;
            dbContactUs = _dbContactUs;
        }
        //Inject DataBase--End
        #endregion

        public IActionResult Index()
        {
           return View();
        }
        public IActionResult Test1(string name)
        {
            ContactUs contactUs = new ContactUs()
            {
                Name = name,
            };
            try
            {
                dbContactUs.Insert(contactUs);
                return Json("ok");
            }
            catch (Exception)
            {
                return Json("error");
            }
           
        }

    }
}