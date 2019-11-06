#pragma checksum "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialSlider.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d027316b3de6242304658aaaec0050c37bfc0cfd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Header__PartialSlider), @"mvc.1.0.view", @"/Views/Shared/Header/_PartialSlider.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Header/_PartialSlider.cshtml", typeof(AspNetCore.Views_Shared_Header__PartialSlider))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\_ViewImports.cshtml"
using DibawinWebsite;

#line default
#line hidden
#line 3 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\_ViewImports.cshtml"
using DibawinWebsite.Models.ViewModels;

#line default
#line hidden
#line 4 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 5 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\_ViewImports.cshtml"
using DibawinWebsite.Areas.Identity.Data;

#line default
#line hidden
#line 6 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\_ViewImports.cshtml"
using DibawinWebsite.ClassLibraries.NotificationHandler;

#line default
#line hidden
#line 7 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\_ViewImports.cshtml"
using DibawinWebsite.Models;

#line default
#line hidden
#line 8 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\_ViewImports.cshtml"
using DibawinWebsite.Models.AdminViewModels;

#line default
#line hidden
#line 9 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\_ViewImports.cshtml"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#line 10 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\_ViewImports.cshtml"
using DibawinWebsite.ClassLibraries;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d027316b3de6242304658aaaec0050c37bfc0cfd", @"/Views/Shared/Header/_PartialSlider.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"086bf80823e711701b6e4463115219260ecf48e8", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Header__PartialSlider : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialSlider.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(29, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialSlider.cshtml"
   
    var sliders = _db.TopSlider.Where(x => x.Status && x.SetForFuture == false).OrderBy(x=> x.Priotity).ToList();
    var additionalSliders = _db.TopSlider.Where(
        x =>
            x.Status == true &&
            (x.ShowDateTime.Value.Year >= DateTime.Now.Year && x.ShowDateTime.Value.Month >= DateTime.Now.Month && x.ShowDateTime.Value.Day >= DateTime.Now.Day) &&
            (x.ExpireDateTime.Value.Year <= DateTime.Now.Year && x.ExpireDateTime.Value.Month <= DateTime.Now.Month && x.ExpireDateTime.Value.Day <= DateTime.Now.Day)
        ).ToList();
    if (additionalSliders.Count > 0)
    {
        sliders.AddRange(additionalSliders);
    }

#line default
#line hidden
            BeginContext(729, 156, true);
            WriteLiteral("<!--slider section start-->\r\n<div class=\"hero-section section position-relative\">\r\n    <div class=\"hero-slider section\">\r\n\r\n        <!--Hero Item start-->\r\n");
            EndContext();
#line 25 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialSlider.cshtml"
         if (sliders.Count > 0)
        {
            foreach (var item in sliders)
            {
                if (item.ImagePath != null)
                {

#line default
#line hidden
            BeginContext(1051, 74, true);
            WriteLiteral("                    <div class=\"hero-item large-height bg-image\" data-bg=\"");
            EndContext();
            BeginContext(1126, 54, false);
#line 31 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialSlider.cshtml"
                                                                     Write(item.ImagePath.Replace("wwwroot","").Replace("\\","/"));

#line default
#line hidden
            EndContext();
            BeginContext(1180, 349, true);
            WriteLiteral(@""">
                        <div class=""container"">
                            <div class=""row"">
                                <div class=""col-12"">

                                    <!--Hero Content start-->
                                    <div class=""hero-content-2 margin-top center"">

                                        <h2>");
            EndContext();
            BeginContext(1530, 10, false);
#line 39 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialSlider.cshtml"
                                       Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(1540, 6, true);
            WriteLiteral(" <br> ");
            EndContext();
            BeginContext(1547, 12, false);
#line 39 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialSlider.cshtml"
                                                        Write(item.Summery);

#line default
#line hidden
            EndContext();
            BeginContext(1559, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
#line 40 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialSlider.cshtml"
                                         if (item.HasButton)
                                        {

#line default
#line hidden
            BeginContext(1671, 75, true);
            WriteLiteral("                                            <a href=\"shop.html\" class=\"btn\"");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 1746, "\"", 1767, 1);
#line 42 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialSlider.cshtml"
WriteAttributeValue("", 1754, item.AltName, 1754, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1768, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1770, 18, false);
#line 42 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialSlider.cshtml"
                                                                                             Write(item.ButtonContent);

#line default
#line hidden
            EndContext();
            BeginContext(1788, 6, true);
            WriteLiteral("</a>\r\n");
            EndContext();
#line 43 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialSlider.cshtml"
                                        }

#line default
#line hidden
            BeginContext(1837, 245, true);
            WriteLiteral("\r\n                                    </div>\r\n                                    <!--Hero Content end-->\r\n\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
            EndContext();
#line 52 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialSlider.cshtml"
                }
            }
        }

#line default
#line hidden
            BeginContext(2127, 87, true);
            WriteLiteral("        <!--Hero Item end-->\r\n        \r\n    </div>\r\n</div>\r\n<!--slider section end-->\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public MyDBContext _db { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
