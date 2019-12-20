using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using DibawinWebsite.Areas.Identity.Data;
using DibawinWebsite.Models;
using DibawinWebsite.Models.ViewModels;
using DibawinWebsite.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
                TempData["UserMessage"] = "اطلاعات کاربری صحیح نمی باشد";
                return RedirectToAction("Login");
            }
            //User Exists
            var CurrentUserStatus = CurrentUser.Status;
            var status = await _signInManager.PasswordSignInAsync(CurrentUser, model.Password, model.IsRemember, false);
            if (status.Succeeded)
            {
                return RedirectToAction("Index", "Home"); //successful signin
            }
            TempData["UserMessage"] = "اطلاعات کاربری صحیح نمی باشد";
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
                TempData["UserMessage"] = "اطلاعات وارد شده صحیح نمی باشد";
                return RedirectToAction("Register");
            }
            var CurrentUser = await _userManager.FindByNameAsync(model.Username);
            if (CurrentUser != null)
            {
                TempData["UserMessage"] = "ایمیل وارد شده دارای حساب کاربری می باشد";
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
                TempData["UserMessage"] = "ثبت نام با موفقیت انجام گرفت";
            }
            return RedirectToAction("Login");
        }
        #endregion
        #region Signout
        public async Task<IActionResult> Logout()
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
        #region RecoverPassword
        public IActionResult RecoverPassword()
        {
            return View();
        }
        public async Task<IActionResult> RecoverPasswordByMail(string Username)
        {
            var CurrentUser = await _userManager.FindByNameAsync(Username);
            if (CurrentUser == null)
            {
                TempData["UserMessage"] = "ایمیل وارد شده دارای حساب کاربری نمی باشد";
                return RedirectToAction("RecoverPassword");
            }
            var user = await _userManager.FindByEmailAsync(Username);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            string href = Url.Action("ResetPassword", "Account",
                new { id = user.Id, token = token }, "https");
            string email = $"Hi <b>{user.UserName} </b><br/>" +
                $"click this <a href='{href}'>link</a> to reset your password.";

            MailMessage msg = new MailMessage("info@dibawin.com", user.Email);
            msg.Subject = "بازیابی رمز";
            msg.Body = email;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.High;

            SmtpClient smtpClient = new SmtpClient("mail.dibawin.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential("info@dibawin.com",
                "K#b4x76d");
           // smtpClient.EnableSsl = true;
            smtpClient.Send(msg);
            TempData["RecoverPasswordSend"] = "ok";
            return RedirectToAction("RecoverPassword");
        }
         public IActionResult ResetPassword(string id, string token)
        {
            HttpContext.Session.SetString("token", token);
            HttpContext.Session.SetString("id", id);
            return View();
        }
        public async Task<IActionResult> ResetPasswordConfirm(string newpassword)
        {
            var token = HttpContext.Session.GetString("token");
            var id = HttpContext.Session.GetString("id");
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.ResetPasswordAsync(user, token, newpassword);
            TempData["UserMessage"] = "رمز شما با موفقیت تغییر کرد";
            return RedirectToAction("Login", "Account");
        }
        #endregion
        #region UserProfile
        public IActionResult UserProfile()
        {
            return View();
        }
        #endregion

    }
}