#pragma checksum "C:\Users\HP\source\repos\Helperland_Project\Helperland_Project\Views\Home\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9cd85fffbeb6c0c04bb2711698b54de1c6e03427"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_About), @"mvc.1.0.view", @"/Views/Home/About.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\Helperland_Project\Helperland_Project\Views\_ViewImports.cshtml"
using Helperland_Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\Helperland_Project\Helperland_Project\Views\_ViewImports.cshtml"
using Helperland_Project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9cd85fffbeb6c0c04bb2711698b54de1c6e03427", @"/Views/Home/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ee062c80a0e07be527800060e4d623f548c03c5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/About.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\HP\source\repos\Helperland_Project\Helperland_Project\Views\Home\About.cshtml"
  
    Layout = "/Views/Shared/Custom_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9cd85fffbeb6c0c04bb2711698b54de1c6e034274195", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9cd85fffbeb6c0c04bb2711698b54de1c6e034274457", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <title>Price</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<!--about banner starts-->
<img src=""../image/about-banner.png"" class=""img-fluid align-items-stretch"" id=""banner"">
<!--about  banner ends-->

<main>
    <!--about us section starts-->
    <section>
        <h1 class=""d-flex justify-content-center contact_title"">A Few words about us</h1>
        <div class=""d-flex justify-content-center"">
            <hr class=""line1"">
            <img src=""../image/star.png"" class=""star"">
            <hr class=""line2"">
        </div>

        <div class=""container about-text justify-content-center"">
            <p class=""para text-center"">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean molestie
                convallis tempor. Duis vestibulum vel risus condimentum dictum.<br> Orci varius natoque penatibus et
                magnis dis parturient montes, nascetur ridiculus mus. Vivamus quis enim orci. Fusce risus lacus,
                <br>sollicitudin eu magna sed, pharetra sodales libero. Proin tincidunt vel erat id po");
            WriteLiteral(@"rttitor.
                Donec tristique est arcu, sed dignissim velit vulputate <br>ultricies.
            </p>
            <p class=""para text-center"">
                Interdum et malesuada fames ac ante ipsum primis in faucibus. In hac
                habitasse platea dictumst. Vivamus eget mauris eget nisl euismod <br>volutpat sed sed libero.
                Quisque sit amet lectus ex. Ut semper ligula et mauris tincidunt hendrerit. Aenean ut rhoncus orci,
                vel elementum <br>turpis. Donec tempor aliquet magna eu fringilla. Nam lobortis libero ut odio
                finibus lobortis. In hac habitasse platea dictumst. Mauris a <br>hendrerit felis. Praesent ac
                vehicula ipsum, at porta tellus. Sed dolor augue, posuere sed neque eget, aliquam ultricies velit.
                Sed lacus elit, <br>tincidunt et massa ac, vehicula placerat lorem.
            </p>
        </div>
    </section>

    <section>
        <h1 class=""d-flex justify-content-center contact_titl");
            WriteLiteral(@"e"">Our Story</h1>
        <div class=""d-flex justify-content-center"">
            <hr class=""line1"">
            <img src=""../image/star.png"" class=""star"">
            <hr class=""line2"">
        </div>

        <div class=""container story-text justify-content-center"">
            <p class=""para text-center"">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean molestie
                convallis tempor. Duis vestibulum vel risus condimentum dictum.<br> Orci varius natoque penatibus et
                magnis dis parturient montes, nascetur ridiculus mus. Vivamus quis enim orci. Fusce risus lacus,
                <br>sollicitudin eu magna sed, pharetra sodales libero. Proin tincidunt vel erat id porttitor.
                Donec tristique est arcu, sed dignissim velit vulputate <br>ultricies.
            </p>

            <p class=""para text-center"">
                Interdum et malesuada fames ac ante ipsum primis in faucibus. In hac habitasse platea dictumst.
        ");
            WriteLiteral(@"        Vivamus eget mauris eget nisl euismod<br> volutpat sed sed libero. Quisque sit amet lectus ex. Ut semper
                ligula et mauris tincidunt hendrerit.<br>
            </p>

            <p class=""para text-center"">
                Aenean ut rhoncus orci, vel elementum turpis. Donec tempor aliquet magna eu
                fringilla. Nam lobortis libero ut odio finibus lobortis. In hac <br>habitasse platea dictumst.
                Mauris a hendrerit felis. Praesent ac vehicula ipsum, at porta tellus. Sed dolor augue, posuere sed
                neque eget,<br> aliquam ultricies velit. Sed lacus elit, tincidunt et massa ac, vehicula placerat
                lorem.
            </p>

        </div>

    </section>
</main>
<!--about us section ends-->
");
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
