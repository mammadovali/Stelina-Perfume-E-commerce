#pragma checksum "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shared\Components\AboutCompany\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec51577ecefd1ea2f14d687245197dd32d07350e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_AboutCompany_Default), @"mvc.1.0.view", @"/Views/Shared/Components/AboutCompany/Default.cshtml")]
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
#line 1 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\_ViewImports.cshtml"
using Stelina.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\_ViewImports.cshtml"
using Stelina.Domain.Models.ViewModels.ContactPostDetail;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\_ViewImports.cshtml"
using Stelina.Domain.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\_ViewImports.cshtml"
using Stelina.Domain.AppCode.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\_ViewImports.cshtml"
using Stelina.Domain.AppCode.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\_ViewImports.cshtml"
using Stelina.Domain.Models.FormModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\_ViewImports.cshtml"
using Stelina.Domain.Models.ViewModels.LoginRegister;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\_ViewImports.cshtml"
using Stelina.Domain.Models.ViewModels.BlogPostItems;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\_ViewImports.cshtml"
using Stelina.Domain.Models.ViewModels.ProductViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\_ViewImports.cshtml"
using Stelina.Domain.Models.ViewModels.Wishlist;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\_ViewImports.cshtml"
using Stelina.Domain.Models.ViewModels.OrderViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec51577ecefd1ea2f14d687245197dd32d07350e", @"/Views/Shared/Components/AboutCompany/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0c8a3e698fbc329859027b46d2096a5caaf464f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_AboutCompany_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<About>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 5 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shared\Components\AboutCompany\Default.cshtml"
         foreach (var item in Model)
       {  

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""col-md-4 col-sm-4"">
            <div class=""stelina-iconbox default"">
                <div class=""iconbox-inner"">
                    <div class=""icon-item"">
                        <span class=""icon flaticon-rocket-ship""></span>
                    </div>
                    <div class=""content"">
                        <h4 class=""title"">Free Delivery</h4>
                        <div class=""text"">
                            ");
#nullable restore
#line 16 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shared\Components\AboutCompany\Default.cshtml"
                       Write(item.FreeDeliveryText);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-md-4 col-sm-4"">
            <div class=""stelina-iconbox default"">
                <div class=""iconbox-inner"">
                    <div class=""icon-item"">
                        <span class=""icon flaticon-return""></span>
                    </div>
                    <div class=""content"">
                        <h4 class=""title"">Money Guarantee</h4>
                        <div class=""text"">
                            ");
#nullable restore
#line 31 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shared\Components\AboutCompany\Default.cshtml"
                       Write(item.MoneyGuaranteeText);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-md-4 col-sm-4"">
            <div class=""stelina-iconbox default"">
                <div class=""iconbox-inner"">
                    <div class=""icon-item"">
                        <span class=""icon flaticon-padlock""></span>
                    </div>
                    <div class=""content"">
                        <h4 class=""title"">Online Support 24/7</h4>
                        <div class=""text"">
                            ");
#nullable restore
#line 46 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shared\Components\AboutCompany\Default.cshtml"
                       Write(item.OnlineSupportText);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 52 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shared\Components\AboutCompany\Default.cshtml"
       }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<About>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
