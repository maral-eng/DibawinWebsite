using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DibawinWebsite.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin,SuperVisor")]
    [Area("Admin")]
    public class ServicesController : Controller
    {

        [HttpPost]
        public IActionResult UploadFiles()
        {
            var files = HttpContext.Request.Form.Files;
            //var p = HttpContext.Request.
            return Ok();
        }

        public IActionResult RemoveFiles(JsonResult file)
        {
            var f = JsonConvert.SerializeObject(file);
            return Ok();
        }
    }
}