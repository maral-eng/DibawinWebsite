using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DibawinWebsite.ClassLibraries.MenuGenrator.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DibawinWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperVisor")]
    [MenuItem(Title = "دیجیتال مارکتینگ", CssIcon = "ion ion-android-bulb", Order = 4)]
    public class DigitalMarketingController : Controller
    {
        #region Tags
        [MenuItem(Title = "مدیریت تگ ها")]
        public ViewResult TagsManager()
        {
            return View();
        }
        #endregion
        #region ShortLinks
        [MenuItem(Title = "کوتاه کننده لینک")]
        public ViewResult ShortLinks()
        {
            return View();
        }
        #endregion
        #region ShortLinks
        [MenuItem(Title = "مدیریت متاتگ ها")]
        public ViewResult MetaTagsManager()
        {
            return View();
        }
        #endregion
    }
}