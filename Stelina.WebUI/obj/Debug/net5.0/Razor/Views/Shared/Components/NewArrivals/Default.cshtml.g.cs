#pragma checksum "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shared\Components\NewArrivals\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "827a22a0f61644c29d5d83a4d057cde335959ee7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_NewArrivals_Default), @"mvc.1.0.view", @"/Views/Shared/Components/NewArrivals/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"827a22a0f61644c29d5d83a4d057cde335959ee7", @"/Views/Shared/Components/NewArrivals/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0c8a3e698fbc329859027b46d2096a5caaf464f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_NewArrivals_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Product>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "shop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Stelina.Domain.AppCode.TagHelpers.RateStarTagHelper __Stelina_Domain_AppCode_TagHelpers_RateStarTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"stelina-product\">\r\n    <ul class=\"row list-products auto-clear equal-container product-grid\">\r\n");
#nullable restore
#line 5 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shared\Components\NewArrivals\Default.cshtml"
         foreach (var item in Model)
        {
            var imagePath = item.Images.FirstOrDefault().Name;


#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <li class=""product-item col-lg-3 col-md-4 col-sm-6 col-xs-6 col-ts-12 style-1"">
            <div class=""product-inner equal-element"">
                <div class=""product-top"">
                    <div class=""flash"">
                        <span class=""onnew"">
                            <span class=""text""> new </span>
                        </span>
                    </div>
                </div>
                <div class=""product-thumb"">
                    <div class=""thumb-inner"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "827a22a0f61644c29d5d83a4d057cde335959ee77982", async() => {
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "827a22a0f61644c29d5d83a4d057cde335959ee78265", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 896, "~/uploads/images/", 896, 17, true);
#nullable restore
#line 21 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shared\Components\NewArrivals\Default.cshtml"
AddHtmlAttributeValue("", 913, imagePath, 913, 10, false);

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
                WriteLiteral("\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 20 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shared\Components\NewArrivals\Default.cshtml"
                                                                        WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
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
            WriteLiteral(@"
                        <div class=""thumb-group"">
                            <div class=""yith-wcwl-add-to-wishlist"">
                                <div class=""yith-wcwl-add-button"">
                                    <a href=""#"">Add to Wishlist</a>
                                </div>
                            </div>
                            <div class=""loop-form-add-to-cart"">
                                <button class=""single_add_to_cart_button button"">
                                    Add to cart
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""product-info"">
                    <h5 class=""product-name product_title"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "827a22a0f61644c29d5d83a4d057cde335959ee713029", async() => {
#nullable restore
#line 39 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shared\Components\NewArrivals\Default.cshtml"
                                                                                         Write(item.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 39 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shared\Components\NewArrivals\Default.cshtml"
                                                                        WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n                    </h5>\r\n                    <div class=\"group-info\">\r\n                        <div class=\"stars-rating\">\r\n                               ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("rate", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "827a22a0f61644c29d5d83a4d057cde335959ee715950", async() => {
            }
            );
            __Stelina_Domain_AppCode_TagHelpers_RateStarTagHelper = CreateTagHelper<global::Stelina.Domain.AppCode.TagHelpers.RateStarTagHelper>();
            __tagHelperExecutionContext.Add(__Stelina_Domain_AppCode_TagHelpers_RateStarTagHelper);
#nullable restore
#line 43 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shared\Components\NewArrivals\Default.cshtml"
__Stelina_Domain_AppCode_TagHelpers_RateStarTagHelper.RateValue = item.Rate;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("rate-value", __Stelina_Domain_AppCode_TagHelpers_RateStarTagHelper.RateValue, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 43 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shared\Components\NewArrivals\Default.cshtml"
__Stelina_Domain_AppCode_TagHelpers_RateStarTagHelper.ProductId = item.Id;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("rate-product-id", __Stelina_Domain_AppCode_TagHelpers_RateStarTagHelper.ProductId, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"price\">\r\n                            <ins> ");
#nullable restore
#line 46 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shared\Components\NewArrivals\Default.cshtml"
                             Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ₼ </ins>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </li>\r\n");
#nullable restore
#line 52 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shared\Components\NewArrivals\Default.cshtml"
       }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Product>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
