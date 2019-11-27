using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DibawinWebsite.ClassLibraries.GenerateCode;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DibawinWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperVisor")]
    public class ServicesController : Controller
    {

        [HttpPost]
        public IActionResult UploadFiles(string refferedAction)
        {
            var files = HttpContext.Request.Form.Files;
            //var p = HttpContext.Request.
            return Ok(refferedAction);
        }

        public IActionResult RemoveFiles(JsonResult file)
        {
            var f = JsonConvert.SerializeObject(file);
            return Ok();
        }

        public IActionResult CodeGenerator(string name)
        {
            try
            {
                string code = GenerateCode.SystemCode(name);
                return Ok(code);
            }
            catch(Exception ex)
            {
                return NoContent();
            }
        }
    }
}