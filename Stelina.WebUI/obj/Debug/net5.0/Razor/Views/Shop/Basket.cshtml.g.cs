#pragma checksum "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shop\Basket.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f3faa8410975a31f0bec3f53efe24882d82c055"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shop_Basket), @"mvc.1.0.view", @"/Views/Shop/Basket.cshtml")]
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
#line 4 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\_ViewImports.cshtml"
using Stelina.Domain.Models.ViewModels.ContactPostDetail;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\_ViewImports.cshtml"
using Stelina.Domain.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\_ViewImports.cshtml"
using Stelina.Domain.AppCode.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\_ViewImports.cshtml"
using Stelina.Domain.AppCode.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\_ViewImports.cshtml"
using Stelina.Domain.Models.FormModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\_ViewImports.cshtml"
using Stelina.Domain.Models.ViewModels.LoginRegister;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\_ViewImports.cshtml"
using Stelina.Domain.Models.ViewModels.BlogPostItems;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\_ViewImports.cshtml"
using Stelina.Domain.Models.ViewModels.ProductViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\_ViewImports.cshtml"
using Stelina.Domain.Models.ViewModels.Wishlist;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f3faa8410975a31f0bec3f53efe24882d82c055", @"/Views/Shop/Basket.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13a25d1003d7ff6aa998f0b20336fd3dd7764559", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shop_Basket : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Basket>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("attachment-shop_thumbnail size-shop_thumbnail wp-post-image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("title"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("cart-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("button btn-continue-shopping"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "shop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("button btn-cart-to-checkout"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "checkout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shop\Basket.cshtml"
  
    ViewData["Title"] = "Checkout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""site-content"">
    <main class=""site-main main-container no-sidebar"">
        <div class=""container"">
            <div class=""breadcrumb-trail breadcrumbs"">
                <ul class=""trail-items breadcrumb"">
                    <li class=""trail-item trail-begin"">
                        <a href=""#"">
                            <span> Home </span>
                        </a>
                    </li>
                    <li class=""trail-item trail-end active"">
                        <span> Shopping Cart </span>
                    </li>
                </ul>
            </div>
            <div class=""row"">
                <div class=""main-content-cart main-content col-sm-12"">
                    <h3 class=""custom_blog_title"">Shopping Cart</h3>
                    <div class=""page-main-content"">
                        <div class=""shoppingcart-content"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f3faa8410975a31f0bec3f53efe24882d82c05511021", async() => {
                WriteLiteral(@"
                                <table class=""shop_table"">
                                    <thead>
                                        <tr>
                                            <th class=""product-remove""></th>
                                            <th class=""product-thumbnail""></th>
                                            <th class=""product-name""></th>
                                            <th class=""product-price""></th>
                                            <th class=""product-quantity""></th>
                                            <th class=""product-subtotal""></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        
");
#nullable restore
#line 41 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shop\Basket.cshtml"
                                         foreach (var item in Model)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <tr");
                BeginWriteAttribute("class", " class=\"", 1992, "\"", 2037, 3);
                WriteAttributeValue("", 2000, "cart_item", 2000, 9, true);
                WriteAttributeValue(" ", 2009, "basket-item-", 2010, 13, true);
#nullable restore
#line 43 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shop\Basket.cshtml"
WriteAttributeValue("", 2022, item.ProductId, 2022, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                                <td class=\"product-remove\">\r\n                                                    <a");
                BeginWriteAttribute("onclick", " onclick=\"", 2172, "\"", 2233, 4);
                WriteAttributeValue("", 2182, "removeFromBasket(this,", 2182, 22, true);
                WriteAttributeValue(" ", 2204, "\'", 2205, 2, true);
#nullable restore
#line 45 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shop\Basket.cshtml"
WriteAttributeValue("", 2206, item.Product.Name, 2206, 18, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2224, "\');return", 2224, 9, true);
                EndWriteAttribute();
                WriteLiteral(" \r\n                                                    class=\"remove\"\r\n                                                    data-product-id=\"");
#nullable restore
#line 47 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shop\Basket.cshtml"
                                                                Write(item.ProductId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\"");
                BeginWriteAttribute("aria-remove-target", "\r\n                                                    aria-remove-target=\"", 2390, "\"", 2492, 2);
                WriteAttributeValue("", 2464, ".basket-item-", 2464, 13, true);
#nullable restore
#line 48 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shop\Basket.cshtml"
WriteAttributeValue("", 2477, item.ProductId, 2477, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></a>\r\n                                                </td>\r\n                                                <td class=\"product-thumbnail\">\r\n                                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f3faa8410975a31f0bec3f53efe24882d82c05515145", async() => {
                    WriteLiteral("\r\n                                                        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8f3faa8410975a31f0bec3f53efe24882d82c05515465", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    AddHtmlAttributeValue("", 2826, "~/assets/images/", 2826, 16, true);
#nullable restore
#line 52 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shop\Basket.cshtml"
AddHtmlAttributeValue("", 2842, item.Product.Images.FirstOrDefault()?.Name, 2842, 43, false);

#line default
#line hidden
#nullable disable
                    EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                                                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 51 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shop\Basket.cshtml"
                                                                                              WriteLiteral(item.ProductId);

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
                WriteLiteral("\r\n                                                </td>\r\n                                                <td class=\"product-name\" data-title=\"Product\">\r\n                                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f3faa8410975a31f0bec3f53efe24882d82c05519773", async() => {
#nullable restore
#line 58 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shop\Basket.cshtml"
                                                                                                                                    Write(item.Product.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 58 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shop\Basket.cshtml"
                                                                                              WriteLiteral(item.ProductId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                                </td>

                                                <td class=""product-quantity"" data-title=""Quantity"">
                                                    <div class=""quantity"">
                                                        <div class=""control"">
                                                            <a class=""btn-number qtyminus quantity-minus""
                                                           href=""#"">-</a>
                                                            <input
                                                               data-product-id=""");
#nullable restore
#line 67 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shop\Basket.cshtml"
                                                                           Write(item.ProductId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\"\r\n                                                               type=\"number\"\r\n                                                               min=\"1\"");
                BeginWriteAttribute("value", "\r\n                                                               value=\"", 4264, "\"", 4350, 1);
#nullable restore
#line 70 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shop\Basket.cshtml"
WriteAttributeValue("", 4336, item.Quantity, 4336, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@"
                                                               title=""Qty""
                                                               class=""input-qty qty""
                                                               size=""4""
                                                               onchange=""changeQuantity(event, this)""/>
                                                            <a href=""#""
                                                           class=""btn-number qtyplus quantity-plus"">+</a>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class=""product-price"" data-title=""Price"">
                                                    <span class=""woocommerce-Price-amount amount"">
                                                        ");
#nullable restore
#line 82 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shop\Basket.cshtml"
                                                    Write((item.Product.Price * item.Quantity).ToString("0.00"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                        <span class=""woocommerce-Price-currencySymbol"">
                                                            ₼
                                                        </span>
                                                    </span>
                                                </td>
                                            </tr>
");
#nullable restore
#line 89 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shop\Basket.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        <tr>\r\n                                            <td class=\"actions actions-basket\">\r\n\r\n");
#nullable restore
#line 94 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shop\Basket.cshtml"
                                                   if (Model.Count() == 0)
                                                  {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                      <div class=\"no-product\">There is no product in your cart</div>\r\n");
#nullable restore
#line 97 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shop\Basket.cshtml"
                                                  }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                                
                                                <div class=""order-total"">
                                                    <span class=""title""> Total Price: </span>
                                                    <span id=""summary"" class=""total-price"">");
#nullable restore
#line 101 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Shop\Basket.cshtml"
                                                                                      Write(Model.Sum(p => (p.Product.Price * p.Quantity)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@" ₼</span>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            <div class=\"control-cart\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f3faa8410975a31f0bec3f53efe24882d82c05529324", async() => {
                WriteLiteral("\r\n                                    Continue Shopping\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f3faa8410975a31f0bec3f53efe24882d82c05530971", async() => {
                WriteLiteral("\r\n                                    Checkout\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </main>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Basket>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
