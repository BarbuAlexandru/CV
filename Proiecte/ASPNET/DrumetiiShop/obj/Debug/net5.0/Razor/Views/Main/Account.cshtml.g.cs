#pragma checksum "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Account.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23890e0a19a077ff160dd08a3984ad89ab6084e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Main_Account), @"mvc.1.0.view", @"/Views/Main/Account.cshtml")]
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
#nullable restore
#line 1 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\_ViewImports.cshtml"
using DrumetiiShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\_ViewImports.cshtml"
using DrumetiiShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23890e0a19a077ff160dd08a3984ad89ab6084e7", @"/Views/Main/Account.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"493bc07f862adae1eeedf97a96bf5fd3a60504cf", @"/Views/_ViewImports.cshtml")]
    public class Views_Main_Account : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Account.cshtml"
  
    ViewData["Title"] = "Account";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"display-4\" style=\"text-align:center;\">");
#nullable restore
#line 5 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Account.cshtml"
                                            Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Information</h1><br><br><br>\r\n\r\n<div style=\"text-align:center; font-size:25px;\">\r\n    <p>This page shows information about current account.</p>\r\n    <p><b>Id:</b> ");
#nullable restore
#line 9 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Account.cshtml"
             Write(Program.currentUser.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p><b>Email:</b> ");
#nullable restore
#line 10 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Account.cshtml"
                Write(Program.currentUser.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p><b>Role:</b> ");
#nullable restore
#line 11 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Account.cshtml"
               Write(Program.currentUser.Role);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n</div>");
        }
        #pragma warning restore 1998
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
