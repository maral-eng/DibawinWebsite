#pragma checksum "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialMiniCart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2526256b63aee48e845d74d0853344152254843"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Header__PartialMiniCart), @"mvc.1.0.view", @"/Views/Shared/Header/_PartialMiniCart.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Header/_PartialMiniCart.cshtml", typeof(AspNetCore.Views_Shared_Header__PartialMiniCart))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2526256b63aee48e845d74d0853344152254843", @"/Views/Shared/Header/_PartialMiniCart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"086bf80823e711701b6e4463115219260ecf48e8", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Header__PartialMiniCart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Invoice", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ShowPurchuseCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/temp_images/cart/cart1.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PaymentInitialize", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(76, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialMiniCart.cshtml"
  
    bool status = false;
    int sum = 0;
    List<InvoiceProduct> dbViewModel = null;
    if (User.Identity.IsAuthenticated)
    {

        Task.WaitAll(Task.Delay(10));
        ApplicationUser currentUser = await userManager.FindByNameAsync(User.Identity.Name);

        var invoiceUser = db.Invoice.Where(e => e.CustomerId == currentUser.Id && e.IsPaid == false);
        if (invoiceUser != null)
        {
            status = true;
            var d = db.InvoiceProduct.Where(e => e.InvoiceId == invoiceUser.FirstOrDefault().Id);
            sum = (int)d.Sum(e => e.Count * e.ProductFeature.ProductAbstract.BasePrice).Value;
            dbViewModel = db.InvoiceProduct.Include(e => e.ProductFeature).
                Include(e => e.ProductFeature.ProductAbstract).
                Include(e => e.ProductFeature.ProductAbstract.ProductImage).
                Include(e => e.Invoice).Where(e => e.InvoiceId == invoiceUser.FirstOrDefault().Id).ToList();
        }
    }

#line default
#line hidden
            BeginContext(1078, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 28 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialMiniCart.cshtml"
 if (User.Identity.IsAuthenticated && sum > 0)
{

#line default
#line hidden
            BeginContext(1131, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(1135, 225, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d2526256b63aee48e845d74d08533441522548438227", async() => {
                BeginContext(1193, 132, true);
                WriteLiteral("\r\n        <i class=\"flaticon-shopping-cart\"></i>\r\n        <span class=\"mini-cart-total farsi-num\">\r\n            <b id=\"MiniCartSum\">");
                EndContext();
                BeginContext(1326, 3, false);
#line 33 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialMiniCart.cshtml"
                           Write(sum);

#line default
#line hidden
                EndContext();
                BeginContext(1329, 27, true);
                WriteLiteral("</b>\r\n        </span>\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1360, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1368, 118, true);
            WriteLiteral("    <!--Mini Cart Dropdown Start-->\r\n    <div id=\"divCartMain\" class=\"header-cart\">\r\n        <ul class=\"cart-items\">\r\n");
            EndContext();
#line 42 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialMiniCart.cshtml"
             if (dbViewModel != null)
            {
                foreach (var item in dbViewModel)
                {

#line default
#line hidden
            BeginContext(1610, 147, true);
            WriteLiteral("                    <li class=\"single-cart-item\">\r\n                        <div class=\"cart-img\">\r\n                            <a href=\"cart.html\">");
            EndContext();
            BeginContext(1757, 47, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d2526256b63aee48e845d74d085334415225484311114", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1804, 185, true);
            WriteLiteral("</a>\r\n                        </div>\r\n\r\n                        <div class=\"cart-content\">\r\n                            <h5 class=\"product-name farsi-num\"><a href=\"single-product.html\">");
            EndContext();
            BeginContext(1990, 40, false);
#line 52 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialMiniCart.cshtml"
                                                                                        Write(item.ProductFeature.ProductAbstract.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2030, 80, true);
            WriteLiteral("</a></h5>\r\n                            <span class=\"product-quantity farsi-num\">");
            EndContext();
            BeginContext(2111, 10, false);
#line 53 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialMiniCart.cshtml"
                                                                Write(item.Count);

#line default
#line hidden
            EndContext();
            BeginContext(2121, 77, true);
            WriteLiteral(" ×</span>\r\n                            <span class=\"product-price farsi-num\">");
            EndContext();
            BeginContext(2200, 50, false);
#line 54 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialMiniCart.cshtml"
                                                              Write((int)item.ProductFeature.ProductAbstract.BasePrice);

#line default
#line hidden
            EndContext();
            BeginContext(2251, 165, true);
            WriteLiteral("</span>\r\n                        </div>\r\n                        <div class=\"cart-item-remove\">\r\n                            <a title=\"حذف از سبد\" id=\"btnCartRemove\"");
            EndContext();
            BeginWriteAttribute("invoiceProductId", " invoiceProductId=\"", 2416, "\"", 2443, 1);
#line 57 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialMiniCart.cshtml"
WriteAttributeValue("", 2435, item.Id, 2435, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2444, 191, true);
            WriteLiteral(">\r\n                                <i class=\"fa fa-trash\">\r\n                                </i>\r\n                            </a>\r\n                        </div>\r\n                    </li>\r\n");
            EndContext();
#line 63 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialMiniCart.cshtml"

                }
            }

#line default
#line hidden
            BeginContext(2671, 119, true);
            WriteLiteral("        </ul>\r\n        <div class=\"cart-total rtl-class\">\r\n            <h5>جمع کل : <span class=\"float-left farsi-num\">");
            EndContext();
            BeginContext(2791, 3, false);
#line 68 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialMiniCart.cshtml"
                                                       Write(sum);

#line default
#line hidden
            EndContext();
            BeginContext(2794, 74, true);
            WriteLiteral("</span></h5>\r\n        </div>\r\n        <div class=\"cart-btn\">\r\n            ");
            EndContext();
            BeginContext(2868, 70, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d2526256b63aee48e845d74d085334415225484315728", async() => {
                BeginContext(2926, 8, true);
                WriteLiteral("سبد خرید");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2938, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(2952, 69, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d2526256b63aee48e845d74d085334415225484317322", async() => {
                BeginContext(3011, 6, true);
                WriteLiteral("پرداخت");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3021, 30, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
            EndContext();
            BeginContext(3053, 35, true);
            WriteLiteral("    <!--Mini Cart Dropdown End-->\r\n");
            EndContext();
#line 77 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialMiniCart.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(3100, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(3104, 116, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d2526256b63aee48e845d74d085334415225484319335", async() => {
                BeginContext(3162, 54, true);
                WriteLiteral("\r\n        <i class=\"flaticon-shopping-cart\"></i>\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3220, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 83 "C:\Users\Sadri\Source\Repos\DibawinWebsite2\DibawinWebsite\Views\Shared\Header\_PartialMiniCart.cshtml"
}

#line default
#line hidden
            BeginContext(3225, 51, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d2526256b63aee48e845d74d085334415225484321118", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3276, 521, true);
            WriteLiteral(@"
<script>
    //$('#btnCartRemove').click(function () {
    //    alert('hi');
    //})
    $('#divCartMain').on('click', '#btnCartRemove', function () {
        var btn = $(this);
        var id = $(this).attr('invoiceProductId');
        $.post('/Invoice/RemoveFromCart', { InvoiceProductId: id }, function (value) {
            if (value.status == true) {
                location.reload();
            } else {
                alert('خطایی رخ داده است');
            }

        })
    });
</script>
");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public MyDBContext db { get; private set; }
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