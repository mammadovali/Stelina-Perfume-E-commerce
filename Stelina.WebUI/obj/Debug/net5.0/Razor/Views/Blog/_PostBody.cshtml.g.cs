#pragma checksum "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Blog\_PostBody.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "88d8c26018d4480b39549a0f03cca2a4cc8f5e90"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog__PostBody), @"mvc.1.0.view", @"/Views/Blog/_PostBody.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88d8c26018d4480b39549a0f03cca2a4cc8f5e90", @"/Views/Blog/_PostBody.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3dde8a63b50cd8c61dfdef8a81b51b6e44372a87", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Blog__PostBody : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedViewModel<BlogPost>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Blog\_PostBody.cshtml"
 foreach (var item in Model.Items)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-lg-6 col-md-12 col-sm-12 col-xs-12\">\r\n        <div class=\"blog-item\">\r\n            <div class=\"post-format\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88d8c26018d4480b39549a0f03cca2a4cc8f5e905530", async() => {
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "88d8c26018d4480b39549a0f03cca2a4cc8f5e905805", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 304, "~/uploads/images/", 304, 17, true);
#nullable restore
#line 9 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Blog\_PostBody.cshtml"
AddHtmlAttributeValue("", 321, item.ImagePath, 321, 15, false);

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
                WriteLiteral("\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-slug", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 8 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Blog\_PostBody.cshtml"
                                            WriteLiteral(item.Slug);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-slug", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n            <div class=\"post-info\">\r\n                <div class=\"category-blog\">\r\n                    <span>");
#nullable restore
#line 14 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Blog\_PostBody.cshtml"
                     Write(item.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </div>\r\n                <h3 class=\"post-title\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88d8c26018d4480b39549a0f03cca2a4cc8f5e909984", async() => {
                WriteLiteral("\r\n                        ");
#nullable restore
#line 18 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Blog\_PostBody.cshtml"
                   Write(item.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-slug", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 17 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Blog\_PostBody.cshtml"
                                                WriteLiteral(item.Slug);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-slug", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </h3>\r\n                <div class=\"main-info-post ellipse\" style=\"width: 246px;\">\r\n                    <p class=\"des\">\r\n                        ");
#nullable restore
#line 23 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Blog\_PostBody.cshtml"
                   Write(Html.Raw(item.Body));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </p>
                </div>
                <div class=""author-view"">
                    <div class=""review"">
                        <div class=""view"">
                            <span class=""icon-view"">
                                <i class=""fa fa-eye"" aria-hidden=""true""></i>
                            </span>
                            <span class=""count""> 631 </span>
                        </div>
                        <div class=""s-comments"">
                            <span class=""icon-cmt"">
                                <i class=""fa fa-commenting""
                               aria-hidden=""true""></i>
                            </span>
                            <span class=""count""> 82 </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 46 "C:\Users\Əli\Desktop\Stelina e-commerce\Stelina Solution\Stelina-Perfume-E-commerce\Stelina.WebUI\Views\Blog\_PostBody.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedViewModel<BlogPost>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
