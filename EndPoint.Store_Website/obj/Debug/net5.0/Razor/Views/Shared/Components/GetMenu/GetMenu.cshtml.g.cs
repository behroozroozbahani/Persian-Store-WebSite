#pragma checksum "E:\Projects\Real Projects\BackEnd\Web Application\Persian_Store_WebSite\Project\EndPoint.Store_Website\Views\Shared\Components\GetMenu\GetMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7feec430136c5bcb31ea34d316422b1f89e14e0f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_GetMenu_GetMenu), @"mvc.1.0.view", @"/Views/Shared/Components/GetMenu/GetMenu.cshtml")]
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
#line 1 "E:\Projects\Real Projects\BackEnd\Web Application\Persian_Store_WebSite\Project\EndPoint.Store_Website\Views\_ViewImports.cshtml"
using EndPoint.Site;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Projects\Real Projects\BackEnd\Web Application\Persian_Store_WebSite\Project\EndPoint.Store_Website\Views\_ViewImports.cshtml"
using EndPoint.Site.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "E:\Projects\Real Projects\BackEnd\Web Application\Persian_Store_WebSite\Project\EndPoint.Store_Website\Views\Shared\Components\GetMenu\GetMenu.cshtml"
using Store_Website.Application.Services.Common.Queries.GetMenuItem;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7feec430136c5bcb31ea34d316422b1f89e14e0f", @"/Views/Shared/Components/GetMenu/GetMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87685c89e84078b3e134b89a928accf3d0f04a39", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_GetMenu_GetMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MenuItemDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mega-menu-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\Projects\Real Projects\BackEnd\Web Application\Persian_Store_WebSite\Project\EndPoint.Store_Website\Views\Shared\Components\GetMenu\GetMenu.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "E:\Projects\Real Projects\BackEnd\Web Application\Persian_Store_WebSite\Project\EndPoint.Store_Website\Views\Shared\Components\GetMenu\GetMenu.cshtml"
 foreach (var item in Model)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <li id=\"nav-menu-item\" class=\"menu-item nav-overlay\">\r\n        <a href=\"#\" class=\"current-link-menu\">\r\n            ");
#nullable restore
#line 13 "E:\Projects\Real Projects\BackEnd\Web Application\Persian_Store_WebSite\Project\EndPoint.Store_Website\Views\Shared\Components\GetMenu\GetMenu.cshtml"
       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </a>\r\n\r\n");
#nullable restore
#line 16 "E:\Projects\Real Projects\BackEnd\Web Application\Persian_Store_WebSite\Project\EndPoint.Store_Website\Views\Shared\Components\GetMenu\GetMenu.cshtml"
         if (item.Child.Count() > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <ul class=\"sub-menu is-mega-menu-small\">\r\n\r\n");
#nullable restore
#line 20 "E:\Projects\Real Projects\BackEnd\Web Application\Persian_Store_WebSite\Project\EndPoint.Store_Website\Views\Shared\Components\GetMenu\GetMenu.cshtml"
         foreach (var itemChild in item.Child)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"menu-mega-item menu-item-type-mega-menu item-small\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7feec430136c5bcb31ea34d316422b1f89e14e0f5799", async() => {
                WriteLiteral("\r\n                    ");
#nullable restore
#line 24 "E:\Projects\Real Projects\BackEnd\Web Application\Persian_Store_WebSite\Project\EndPoint.Store_Website\Views\Shared\Components\GetMenu\GetMenu.cshtml"
               Write(itemChild.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 568, "~/products/index?CatId=", 568, 23, true);
#nullable restore
#line 23 "E:\Projects\Real Projects\BackEnd\Web Application\Persian_Store_WebSite\Project\EndPoint.Store_Website\Views\Shared\Components\GetMenu\GetMenu.cshtml"
AddHtmlAttributeValue("", 591, itemChild.CatId, 591, 16, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </li>\r\n");
#nullable restore
#line 27 "E:\Projects\Real Projects\BackEnd\Web Application\Persian_Store_WebSite\Project\EndPoint.Store_Website\Views\Shared\Components\GetMenu\GetMenu.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n");
#nullable restore
#line 29 "E:\Projects\Real Projects\BackEnd\Web Application\Persian_Store_WebSite\Project\EndPoint.Store_Website\Views\Shared\Components\GetMenu\GetMenu.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </li>\r\n");
#nullable restore
#line 32 "E:\Projects\Real Projects\BackEnd\Web Application\Persian_Store_WebSite\Project\EndPoint.Store_Website\Views\Shared\Components\GetMenu\GetMenu.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MenuItemDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
