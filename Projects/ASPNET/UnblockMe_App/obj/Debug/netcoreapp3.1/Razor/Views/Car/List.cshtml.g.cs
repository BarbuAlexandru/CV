#pragma checksum "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e157fee846489c16e1c300fdf21b2e40e75def6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Car_List), @"mvc.1.0.view", @"/Views/Car/List.cshtml")]
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
#line 1 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\_ViewImports.cshtml"
using UnblockMe_App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\_ViewImports.cshtml"
using UnblockMe_App.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e157fee846489c16e1c300fdf21b2e40e75def6", @"/Views/Car/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5bbb34f60687f435cc60a59a5a1fc8854c0f8c33", @"/Views/_ViewImports.cshtml")]
    public class Views_Car_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UnblockMe_App.ViewModels.CarListViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("font-size:25px; float:left; margin-left:10px; color:#003256;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Car", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("buttons"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("font-size:25px; float:right; height:42px; width:180px; margin-right:10px; margin-top:15px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
  
    ViewData["Title"] = "My Cars Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    .buttons {
        width: 105px;
        height: 43px;
        font-size: 18px;
        background-color: #87CDFF;
        color: #2C3517;
        text-align: center;
        text-decoration: none;
        font-weight: bold;
        border-style: solid;
        border-width: 1px;
    }
</style>

<h1 class=""display-4"" style=""text-align:center;"">");
#nullable restore
#line 22 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
                                            Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
<br>

<div style=""text-align:center; font-size:25px;"">

    <hr>
    <!--ADD NEW CAR-->
    <div style=""height:auto; background-color:#70BEFF; border:solid; margin-bottom:20px"">
        <p style=""font-size:25px; text-align:left; margin-left:10px;""><b>Add a new car</b></p>
");
#nullable restore
#line 31 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
         using (Html.BeginForm("List", "Car", FormMethod.Get))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div>
                <input style="" margin-left:10px; margin-bottom:10px; float:left; font-size:25px; vertical-align:bottom; width:300px;"" id=""licencePlate"" name=""licencePlate"" type=""text"" placeholder=""Add a new licence plate..."" autocomplete=""off"" required />
                <input style="" margin-left:10px; margin-bottom:10px; float:left; font-size:25px; vertical-align:bottom; width:250px;"" id=""maker"" name=""maker"" type=""text"" placeholder=""Maker..."" autocomplete=""off"" />
                <input style="" margin-left:10px; margin-bottom:10px; float:left; font-size:25px; vertical-align:bottom; width:250px;"" id=""model"" name=""model"" type=""text"" placeholder=""Model..."" autocomplete=""off"" />
                <input style="" margin-left:10px; margin-bottom:10px; float:left; font-size:25px; vertical-align:bottom; width:250px;"" id=""color"" name=""color"" type=""text"" placeholder=""Color..."" autocomplete=""off"" />
                <input style="" margin-left:10px; margin-bottom:10px; float:left; font-size:25px; ver");
            WriteLiteral(@"tical-align:bottom; width:965px;"" id=""additionalInformation"" name=""additionalInformation"" type=""text"" placeholder=""Additional information..."" autocomplete=""off"" />

                <input class=""buttons"" style=""font-size:25px; margin-left: 10px; float: left;"" type=""submit"" value=""Add"" />
            </div>
            <br><br><br>
");
#nullable restore
#line 43 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n    <hr>\r\n    <!--MY CARS-->\r\n");
#nullable restore
#line 48 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
     if (Model.UserCars.Count == 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p style=\"font-size:25px;\">No cars yet</p>\r\n");
#nullable restore
#line 51 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
    }
    else
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
         foreach (var car in Model.UserCars)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div style=\"height:auto; background-color:#70BEFF; border:solid; margin-bottom:20px\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9e157fee846489c16e1c300fdf21b2e40e75def69107", async() => {
                WriteLiteral("<b>Car ");
#nullable restore
#line 57 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
                                                                                                                                                                    Write(Model.UserCars.IndexOf(car)+1);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - Licence plate: ");
#nullable restore
#line 57 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
                                                                                                                                                                                                                      Write(car.LicencePlate);

#line default
#line hidden
#nullable disable
                WriteLiteral("</b>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 57 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
                                                                                                                                  WriteLiteral(car.LicencePlate);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9e157fee846489c16e1c300fdf21b2e40e75def612496", async() => {
                WriteLiteral("Delete car");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 59 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
                                                                                                                                                                                 WriteLiteral(car.LicencePlate);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9e157fee846489c16e1c300fdf21b2e40e75def615176", async() => {
                WriteLiteral("Edit car details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
                                                                                                                                                                                WriteLiteral(car.LicencePlate);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                \r\n                <br><p style=\"font-size:20px; text-align:left; margin-left:10px;\"><b>Maker: </b>");
#nullable restore
#line 62 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
                                                                                            Write(car.Maker ?? "No info");

#line default
#line hidden
#nullable disable
            WriteLiteral("<b> - Model: </b>");
#nullable restore
#line 62 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
                                                                                                                                      Write(car.Model ?? "No info");

#line default
#line hidden
#nullable disable
            WriteLiteral("<b> - Color: </b>");
#nullable restore
#line 62 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
                                                                                                                                                                                Write(car.Color ?? "No info");

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n");
#nullable restore
#line 64 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
                 if (car.AdditionalInfo != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p style=\"font-size:20px; text-align:left; margin-left:10px;\"><b>Additional information: </b>");
#nullable restore
#line 66 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
                                                                                                             Write(car.AdditionalInfo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 67 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 69 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
                 if (car.BlockedLicencePlate == null && car.BlockedByLicencePlate == null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p style=\"font-size:20px; text-align:left; margin-left:10px;\"><b>Status: </b>OK</p>\r\n");
#nullable restore
#line 72 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p style=\"font-size:20px; text-align:left; margin-left:10px;\"><b>Status:</b>");
#nullable restore
#line 75 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
                                                                                            Write(car.BlockedByLicencePlate != null ? " Blocked /" : null);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 75 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
                                                                                                                                                       Write(car.BlockedLicencePlate != null ? " Blocking" : null);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 76 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n");
#nullable restore
#line 78 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 78 "C:\Users\mirce\Desktop\Proiecte\VS\UnblockMe_App\Views\Car\List.cshtml"
         
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UnblockMe_App.ViewModels.CarListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
