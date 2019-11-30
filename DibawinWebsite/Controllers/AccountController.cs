using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DibawinWebsite.Areas.Identity.Data;
using DibawinWebsite.Models;
using DibawinWebsite.Models.ViewModels;
using DibawinWebsite.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DibawinWebsite.Controllers
{
    public class AccountController : Controller
    {
        #region Inject
        private readonly IHostingEnvironment _hostingEnvironment;
        readonly string contentRootPath;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;
        DbRepository<MyDBContext, UserModified, int> _dbUserModified;
        DbRepository<MyDBContext, UserImage, int> _dbUserImage;
        public AccountController
            (
                IHostingEnvironment hostingEnvironment,
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager,
                RoleManager<IdentityRole> roleManager,
                DbRepository<MyDBContext, UserModified, int> dbUserModified,
                DbRepository<MyDBContext, UserImage, int> dbUserImage
            )
        {
            _hostingEnvironment = hostingEnvironment;
            contentRootPath = _hostingEnvironment.ContentRootPath;//returns the root path of the website
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _dbUserModified = dbUserModified;
            _dbUserImage = dbUserImage;

        }
        #endregion
        #region Index
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }
        #endregion
        #region Login
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> LoginConfirm(SigninViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Login");
            }
            //Model is Valid
            var CurrentUser = await _userManager.FindByNameAsync(model.Username);
            if (CurrentUser == null)
            {
                return RedirectToAction("Login");
            }
            //User Exists
            var CurrentUserStatus = CurrentUser.Status;
            var status = await _signInManager.PasswordSignInAsync(CurrentUser, model.Password, model.IsRemember, false);
            if (status.Succeeded)
            {
                return RedirectToAction("Index", "Home"); //successful signin
            }
            return RedirectToAction("Login");
        }
        #endregion
        #region Register
        public IActionResult Register()
        {
            return View();
        }
        public async Task<IActionResult> RegisterConfirm(SignupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Register");
            }
            var CurrentUser = await _userManager.FindByNameAsync(model.Username);
            if (CurrentUser != null)
            {
                return RedirectToAction("Register");
            }
            ApplicationUser NewUser = new ApplicationUser()
            {
                UserName = model.Username,
                Email = model.Username,
            };
            var status = await _userManager.CreateAsync(NewUser, model.Password);
            if (status.Succeeded)
            {
                await _userManager.AddToRoleAsync(NewUser, "Customer");
            }
            return RedirectToAction("Register");
        }
        #endregion
        #region Signout
        public async Task<IActionResult> Signout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Login");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion
    }
}