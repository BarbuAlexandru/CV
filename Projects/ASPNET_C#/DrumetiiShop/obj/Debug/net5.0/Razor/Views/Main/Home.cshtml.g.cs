#pragma checksum "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6bb00beec3e78d1aa2503e0457d647a3e31c09d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Main_Home), @"mvc.1.0.view", @"/Views/Main/Home.cshtml")]
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
#line 1 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
using DrumetiiShop.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
using DrumetiiShop.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bb00beec3e78d1aa2503e0457d647a3e31c09d9", @"/Views/Main/Home.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"493bc07f862adae1eeedf97a96bf5fd3a60504cf", @"/Views/_ViewImports.cshtml")]
    public class Views_Main_Home : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DrumetiiShop.ViewModels.HomeViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("float:right; font-size:20px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Main", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("buttons"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SeeProduct", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddProductToCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("font-size:30px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
  
    ViewData["Title"] = "Home";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    .buttons {
        width: 105px;
        height: 30px;
        font-size: 18px;
        background-color: #87CDFF;
        color: #2C3517;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-weight: bold;
        border-style: solid;
        border-width: 1px;
    }

    a:hover {
        color: black;
    }

    .autocomplete-items {
        position:absolute;
        border: 1px solid #d4d4d4;
        width: 300px;
    }
    
    .autocomplete-items div {
        padding: 10px;
        cursor: pointer;
        background-color: #fff;
        border-bottom: 1px solid #d4d4d4;
    }
    
    /*when hovering an item:*/
    .autocomplete-items div:hover {
        background-color: #e9e9e9;
    }
    
    /*when navigating through the items using the arrow keys:*/
    .autocomplete-active {
        background-color: DodgerBlue !important; 
        color: #ffffff; 
    }
</style>

<div>
    <div style=""te");
            WriteLiteral("xt-align:center;\">\r\n        <h1 class=\"display-4\">Welcome to Drumetii Shop</h1>\r\n        <p style=\"font-size:25px\">Made by Barbu Mircea</p><br><br>\r\n    </div>\r\n\r\n    <div id=\"SearchProducts\">\r\n        <h1 style=\"font-size:30px\">Search Products</h1><br>\r\n");
#nullable restore
#line 62 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
         using (Html.BeginForm("Home", "Main", FormMethod.Get))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div>
                <input class=""autocomplete"" style=""width:300px;"" id=""searchString"" name=""searchString"" type=""text"" placeholder=""Search for a product..."" autocomplete=""off"" />
                <input class=""buttons"" type=""submit"" value=""Search"" />
");
#nullable restore
#line 67 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
                 if (Model.SearchedText != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6bb00beec3e78d1aa2503e0457d647a3e31c09d98106", async() => {
                WriteLiteral("Clear");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <p style=\"float:right; font-size:20px; margin-right:10px;\">Searched Text: ");
#nullable restore
#line 70 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
                                                                                          Write(Model.SearchedText);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 71 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n");
#nullable restore
#line 73 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <br><br>\r\n    </div>\r\n\r\n    <h1 style=\"font-size:30px\">Product Categories</h1><br>\r\n    <div id=\"products\">\r\n");
#nullable restore
#line 79 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
         foreach (var category in Model.Categories)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p style=\"font-size:25px\">");
#nullable restore
#line 81 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
                                 Write(category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 82 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
             foreach (var product in Model.Products)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 84 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
                 if (String.Equals(product.Category, category))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <table style=""display: inline-block;"" border=""0"">
                        <tbody>
                            <tr>
                                <td>
                                    <table style=""text-align:center; width:220px;"" border=""1"">
                                        <tr>
                                            <th>");
#nullable restore
#line 92 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
                                           Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                        </tr>\r\n                                        <tr>\r\n                                            <td>\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6bb00beec3e78d1aa2503e0457d647a3e31c09d912367", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3097, "~/media/products/pictures/", 3097, 26, true);
#nullable restore
#line 96 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
AddHtmlAttributeValue("", 3123, Program.StandardizeText(product.Name), 3123, 40, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 3163, ".png", 3163, 4, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("\\", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style=""white-space: nowrap; overflow: hidden; max-width: 220px; text-overflow: ellipsis;"">
                                                <b>Description</b><br>
                                                ");
#nullable restore
#line 102 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
                                           Write(product.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                        </tr>\r\n                                        <tr>\r\n                                            <td>\r\n                                                <b>Price: ");
#nullable restore
#line 107 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
                                                      Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" lei</b>\r\n                                            </td>\r\n                                        </tr>\r\n                                        <tr>\r\n                                            <td>\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6bb00beec3e78d1aa2503e0457d647a3e31c09d915706", async() => {
                WriteLiteral("See Product");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 112 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
                                                                                                                   WriteLiteral(product.Id);

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
            WriteLiteral("\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6bb00beec3e78d1aa2503e0457d647a3e31c09d918269", async() => {
                WriteLiteral("Add to Cart");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
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
#line 113 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
                                                                                                                         WriteLiteral(product.Id);

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
            WriteLiteral(@"
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
");
#nullable restore
#line 121 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 121 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <br><br>\r\n");
#nullable restore
#line 124 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 126 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
     if (Model.Products.Count() == 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n            <p style=\"font-size:30px;\">There were no products found</p>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6bb00beec3e78d1aa2503e0457d647a3e31c09d922030", async() => {
                WriteLiteral("Clear Search");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 132 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>


<script>
    function autocomplete(inp, arr) {
        /*the autocomplete function takes two arguments,
        the text field element and an array of possible autocompleted values:*/
        var currentFocus;
        /*execute a function when someone writes in the text field:*/
        inp.addEventListener(""input"", function(e) {
            var a, b, i, val = this.value;
            /*close any already open lists of autocompleted values*/
            closeAllLists();
            if (!val) { return false;}
            currentFocus = -1;
            /*create a DIV element that will contain the items (values):*/
            a = document.createElement(""DIV"");
            a.setAttribute(""id"", this.id + ""autocomplete-list"");
            a.setAttribute(""class"", ""autocomplete-items"");
            /*append the DIV element as a child of the autocomplete container:*/
            this.parentNode.appendChild(a);
            /*for each item in the array...*/
            for (i = 0; i < arr.l");
            WriteLiteral(@"ength; i++) {
                /*check if the item contains the text field value:*/
                if (arr[i].toUpperCase().includes(val.toUpperCase())) {
                    /*create a DIV element for each matching element:*/
                    b = document.createElement(""DIV"");
                    /*make the matching letters bold - Removed because its not only the first letters:*/
                    /*b.innerHTML = ""<strong>"" + arr[i].substr(0, val.length) + ""</strong>"";*/
                    b.innerHTML = arr[i].substr(0, val.length);
                    b.innerHTML += arr[i].substr(val.length);
                    /*insert a input field that will hold the current array item's value:*/
                    b.innerHTML += ""<input type='hidden' value='"" + arr[i] + ""'>"";
                    /*execute a function when someone clicks on the item value (DIV element):*/
                    b.addEventListener(""click"", function(e) {
                        /*insert the value for the autocomplete text f");
            WriteLiteral(@"ield:*/
                        inp.value = this.getElementsByTagName(""input"")[0].value;
                        /*close the list of autocompleted values,
                        (or any other open lists of autocompleted values:*/
                        closeAllLists();
                    });
                    a.appendChild(b);
                }
            }
        });

        /*execute a function presses a key on the keyboard:*/
        inp.addEventListener(""keydown"", function(e) {
            var x = document.getElementById(this.id + ""autocomplete-list"");
            if (x) x = x.getElementsByTagName(""div"");
            if (e.keyCode == 40) {
                /*If the arrow DOWN key is pressed,
                increase the currentFocus variable:*/
                currentFocus++;
                /*and and make the current item more visible:*/
                addActive(x);
            } else if (e.keyCode == 38) { //up
                /*If the arrow UP key is pressed,
            ");
            WriteLiteral(@"    decrease the currentFocus variable:*/
                currentFocus--;
                /*and and make the current item more visible:*/
                addActive(x);
            } else if (e.keyCode == 13) {
                /*If the ENTER key is pressed, prevent the form from being submitted,*/
                e.preventDefault();
                if (currentFocus > -1) {
                    /*and simulate a click on the ""active"" item:*/
                    if (x) x[currentFocus].click();
                }
            }
        });

        function addActive(x) {
            /*a function to classify an item as ""active"":*/
            if (!x) return false;
            /*start by removing the ""active"" class on all items:*/
            removeActive(x);
            if (currentFocus >= x.length) currentFocus = 0;
            if (currentFocus < 0) currentFocus = (x.length - 1);
            /*add class ""autocomplete-active"":*/
            x[currentFocus].classList.add(""autocomplete-active"");
");
            WriteLiteral(@"        }

        function removeActive(x) {
            /*a function to remove the ""active"" class from all autocomplete items:*/
            for (var i = 0; i < x.length; i++) {
                x[i].classList.remove(""autocomplete-active"");
            }
        }

        function closeAllLists(elmnt) {
            /*close all autocomplete lists in the document,
            except the one passed as an argument:*/
            var x = document.getElementsByClassName(""autocomplete-items"");
            for (var i = 0; i < x.length; i++) {
                if (elmnt != x[i] && elmnt != inp) {
                    x[i].parentNode.removeChild(x[i]);
                }
            }
        }

        /*execute a function when someone clicks in the document:*/
        document.addEventListener(""click"", function (e) {
            closeAllLists(e.target);
        });
    }

    /*An array containing all the country names in the world:*/
    var allProducts = JSON.parse('");
#nullable restore
#line 241 "C:\Users\mirce\Desktop\Proiecte\VS\DrumetiiShop\Views\Main\Home.cshtml"
                             Write(Html.Raw(Json.Serialize(@Model.AllProductNames)));

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n\r\n    /*initiate the autocomplete function on the \"myInput\" element, and pass along the products array as possible autocomplete values:*/\r\n    autocomplete(document.getElementById(\"searchString\"), allProducts);\r\n</script>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DrumetiiShop.ViewModels.HomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
