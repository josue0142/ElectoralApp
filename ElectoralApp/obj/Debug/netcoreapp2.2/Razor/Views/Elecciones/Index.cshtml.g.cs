#pragma checksum "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\Elecciones\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9557d1029ef7949085c5f821e494a1e3f7bf6d32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Elecciones_Index), @"mvc.1.0.view", @"/Views/Elecciones/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Elecciones/Index.cshtml", typeof(AspNetCore.Views_Elecciones_Index))]
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
#line 1 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\_ViewImports.cshtml"
using ElectoralApp;

#line default
#line hidden
#line 2 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\_ViewImports.cshtml"
using ElectoralApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9557d1029ef7949085c5f821e494a1e3f7bf6d32", @"/Views/Elecciones/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"332321179308d3bae702b4684e93e3e3a6e9a8c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Elecciones_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ElectoralApp.Models.Elecciones>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-light btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Start", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Stop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(52, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\Elecciones\Index.cshtml"
  
    ViewData["Title"] = "Elecciones";

#line default
#line hidden
            BeginContext(100, 25, true);
            WriteLiteral("\r\n<h1>Elecciones</h1>\r\n\r\n");
            EndContext();
#line 9 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\Elecciones\Index.cshtml"
 if (ViewBag.BtnIniciarPElectivo == true)
{

#line default
#line hidden
            BeginContext(171, 17, true);
            WriteLiteral("    <p>\r\n        ");
            EndContext();
            BeginContext(188, 51, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9557d1029ef7949085c5f821e494a1e3f7bf6d326006", async() => {
                BeginContext(211, 24, true);
                WriteLiteral("Iniciar Proceso Electivo");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(239, 12, true);
            WriteLiteral("\r\n    </p>\r\n");
            EndContext();
#line 14 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\Elecciones\Index.cshtml"
}

#line default
#line hidden
            BeginContext(254, 103, true);
            WriteLiteral("<table class=\"table\">\r\n    <thead class=\"thead-dark\">\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(358, 42, false);
#line 19 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\Elecciones\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(400, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(456, 54, false);
#line 22 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\Elecciones\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FechaDeRealización));

#line default
#line hidden
            EndContext();
            BeginContext(510, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(566, 42, false);
#line 25 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\Elecciones\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Estado));

#line default
#line hidden
            EndContext();
            BeginContext(608, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 31 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\Elecciones\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(743, 85, true);
            WriteLiteral("            <tr class=\"font-weight-bold\">\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(829, 41, false);
#line 35 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\Elecciones\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(870, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(938, 53, false);
#line 38 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\Elecciones\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.FechaDeRealización));

#line default
#line hidden
            EndContext();
            BeginContext(991, 47, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
            EndContext();
#line 41 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\Elecciones\Index.cshtml"
                     if (item.Estado == true)
                    {

#line default
#line hidden
            BeginContext(1108, 45, true);
            WriteLiteral("                        <span>Activo</span>\r\n");
            EndContext();
#line 44 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\Elecciones\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(1225, 47, true);
            WriteLiteral("                        <span>Inactivo</span>\r\n");
            EndContext();
#line 48 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\Elecciones\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(1295, 59, true);
            WriteLiteral("                </td>\r\n                <td align=\"right\">\r\n");
            EndContext();
#line 51 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\Elecciones\Index.cshtml"
                     if (item.Estado == false && item.Resultados.Count == 0)
                    {

#line default
#line hidden
            BeginContext(1455, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(1479, 86, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9557d1029ef7949085c5f821e494a1e3f7bf6d3211660", async() => {
                BeginContext(1554, 7, true);
                WriteLiteral("Iniciar");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 53 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\Elecciones\Index.cshtml"
                                                                             WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1565, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 54 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\Elecciones\Index.cshtml"
                    }
                    else if (item.Estado == true)
                    {

#line default
#line hidden
            BeginContext(1664, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(1688, 87, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9557d1029ef7949085c5f821e494a1e3f7bf6d3214464", async() => {
                BeginContext(1762, 9, true);
                WriteLiteral("Finalizar");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 57 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\Elecciones\Index.cshtml"
                                                                            WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1775, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 58 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\Elecciones\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(1849, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(1873, 91, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9557d1029ef7949085c5f821e494a1e3f7bf6d3217244", async() => {
                BeginContext(1950, 10, true);
                WriteLiteral("Resultados");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 61 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\Elecciones\Index.cshtml"
                                                                               WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1964, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 62 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\Elecciones\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(1989, 42, true);
            WriteLiteral("                </td>\r\n            </tr>\r\n");
            EndContext();
#line 65 "C:\Users\eljos\source\repos\ElectoralApp\ElectoralApp\Views\Elecciones\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(2042, 33, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n<p>\r\n    ");
            EndContext();
            BeginContext(2075, 77, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9557d1029ef7949085c5f821e494a1e3f7bf6d3220280", async() => {
                BeginContext(2120, 28, true);
                WriteLiteral("Volver al Menu Administrador");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2152, 8, true);
            WriteLiteral("\r\n</p>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ElectoralApp.Models.Elecciones>> Html { get; private set; }
    }
}
#pragma warning restore 1591
