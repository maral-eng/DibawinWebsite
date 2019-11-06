using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using DibawinWebsite.Models;
using DibawinWebsite.Areas.Identity.Data;
using DibawinWebsite.ClassLibraries;
using DibawinWebsite.ClassLibraries.NotificationHandler;
using DibawinWebsite.Models.ViewModels;
using DibawinWebsite.Repository;

namespace DibawinWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin,SuperVisor")]
    public class AccountController : Controller
    {
         public IActionResult Index()
        {
            return View();
        }
    }
}