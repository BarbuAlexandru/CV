#pragma checksum "C:\Users\mirce\Desktop\Proiecte\VS\ProMonitor\Views\Project\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e6113a1cd9e3718b1accc6c24e9de0323e09f15e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Project_Create), @"mvc.1.0.view", @"/Views/Project/Create.cshtml")]
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
#line 1 "C:\Users\mirce\Desktop\Proiecte\VS\ProMonitor\Views\_ViewImports.cshtml"
using ProMonitor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mirce\Desktop\Proiecte\VS\ProMonitor\Views\_ViewImports.cshtml"
using ProMonitor.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6113a1cd9e3718b1accc6c24e9de0323e09f15e", @"/Views/Project/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f5f9f62acd2d7cb65f3c3464958decea6cd5b08", @"/Views/_ViewImports.cshtml")]
    public class Views_Project_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\mirce\Desktop\Proiecte\VS\ProMonitor\Views\Project\Create.cshtml"
  
    ViewData["Title"] = "Create Project Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"display-4\" style=\"text-align:center;\">");
#nullable restore
#line 5 "C:\Users\mirce\Desktop\Proiecte\VS\ProMonitor\Views\Project\Create.cshtml"
                                            Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<br>\r\n\r\n<div style=\"text-align:center; font-size:25px;\">\r\n    <hr>\r\n    <p>Create a new project</p>\r\n\r\n");
#nullable restore
#line 12 "C:\Users\mirce\Desktop\Proiecte\VS\ProMonitor\Views\Project\Create.cshtml"
     using (Html.BeginForm("Create", "Project", FormMethod.Get))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div>
            <p>Title</p>
            <input style=""width:500px;"" id=""title"" name=""title"" type=""text"" placeholder=""Title..."" autocomplete=""off"" required /><br><br>
            <p>Description</p>
            <textarea style=""width:500px;"" id=""description"" name=""description"" type=""text"" placeholder=""Description..."" autocomplete=""off""></textarea><br><br>
            <p>Budget</p>
            <input style=""width:200px;"" id=""buget"" name=""buget"" type=""number"" placeholder=""Budget..."" autocomplete=""off"" /><br><br>
            <p>Start date</p>
            <input style=""width:200px;"" id=""startDate"" name=""startDate"" type=""date"" placeholder=""Start date..."" autocomplete=""off"" /><br><br>
            <p>Estimated end date</p>
            <input style=""width:200px;"" id=""estimatedEndDate"" name=""estimatedEndDate"" type=""date"" placeholder=""Estimated end date..."" autocomplete=""off"" /><br><br>
            <input class=""btn btn-primary"" type=""submit"" value=""Create new project"" />
        </div>
");
#nullable restore
#line 27 "C:\Users\mirce\Desktop\Proiecte\VS\ProMonitor\Views\Project\Create.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
