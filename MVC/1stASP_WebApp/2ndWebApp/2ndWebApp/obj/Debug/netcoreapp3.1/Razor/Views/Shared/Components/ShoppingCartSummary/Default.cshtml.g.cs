#pragma checksum "C:\Users\Nuno\Desktop\Github\RPA_C#\Pluralsight\MVC\1stASP_WebApp\2ndWebApp\2ndWebApp\Views\Shared\Components\ShoppingCartSummary\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98f34a91d7793e2554d44aa4ff2f65475fbe9d51"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ShoppingCartSummary_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ShoppingCartSummary/Default.cshtml")]
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
#line 1 "C:\Users\Nuno\Desktop\Github\RPA_C#\Pluralsight\MVC\1stASP_WebApp\2ndWebApp\2ndWebApp\Views\_ViewImports.cshtml"
using _2ndWebApp.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Nuno\Desktop\Github\RPA_C#\Pluralsight\MVC\1stASP_WebApp\2ndWebApp\2ndWebApp\Views\_ViewImports.cshtml"
using _2ndWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98f34a91d7793e2554d44aa4ff2f65475fbe9d51", @"/Views/Shared/Components/ShoppingCartSummary/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30f6b9619bdef708f4ee9d20b184c7503d2e6b9a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ShoppingCartSummary_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShoppingCartViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Nuno\Desktop\Github\RPA_C#\Pluralsight\MVC\1stASP_WebApp\2ndWebApp\2ndWebApp\Views\Shared\Components\ShoppingCartSummary\Default.cshtml"
 if (Model.ShoppingCart.ShoppingCartItems.Count > 0)
{ 

#line default
#line hidden
#nullable disable
            WriteLiteral("<li>\r\n    <a>\r\n        <span class=\"glyphicon glyphicon-shopping-cart\"></span>\r\n        <span id=\"cartstatus\">");
#nullable restore
#line 8 "C:\Users\Nuno\Desktop\Github\RPA_C#\Pluralsight\MVC\1stASP_WebApp\2ndWebApp\2ndWebApp\Views\Shared\Components\ShoppingCartSummary\Default.cshtml"
                         Write(Model.ShoppingCart.ShoppingCartItems.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    </a>\r\n\r\n</li>\r\n");
#nullable restore
#line 12 "C:\Users\Nuno\Desktop\Github\RPA_C#\Pluralsight\MVC\1stASP_WebApp\2ndWebApp\2ndWebApp\Views\Shared\Components\ShoppingCartSummary\Default.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShoppingCartViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
