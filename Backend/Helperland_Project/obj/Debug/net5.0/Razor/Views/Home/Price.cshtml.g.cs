#pragma checksum "C:\Users\HP\source\repos\Helperland_Project\Helperland_Project\Views\Home\Price.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f517a31b3fa4b6e69820a3ee6282c3dfa420899b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Price), @"mvc.1.0.view", @"/Views/Home/Price.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f517a31b3fa4b6e69820a3ee6282c3dfa420899b", @"/Views/Home/Price.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ee062c80a0e07be527800060e4d623f548c03c5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Price : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Price.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "C:\Users\HP\source\repos\Helperland_Project\Helperland_Project\Views\Home\Price.cshtml"
  
    Layout = "/Views/Shared/Custom_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f517a31b3fa4b6e69820a3ee6282c3dfa420899b4195", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f517a31b3fa4b6e69820a3ee6282c3dfa420899b4457", async() => {
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

<!--price image starts-->
<img src=""../image/price-banner.png"" class=""img-fluid align-items-stretch"" id=""banner"">

<!--price image ends-->
<!--price title starts-->
<div class=""d-flex justify-content-center price_title"">Prices</div>
<div class=""d-flex justify-content-center"">
    <hr class=""line1"">
    <img src=""../image/star.png"" class=""star"">
    <hr class=""line2"">
</div>
<!--price title ends-->
<!--one time section starts-->
<section>
    <div class=""row justify-content-center flex-wrap"">
        <div class=""col-lg-12 mt-3 mb-5 one-time"">
            <div class=""container mt-5"">
                <div class=""card border border-2"">
                    <div class=""card-body ps-0 pt-0 pe-0"">
                        <div class=""card-title text-center justify-content-center onetime-title"">
                            <span class=""text-center"">One Time</span>
                        </div>
                        <div class=""container mt-3 text-center onetime-body"">
                     ");
            WriteLiteral(@"       <span class=""align-baseline dollar"">&#128;&nbsp20</span>
                            <span class=""align-text-bottom hour"">/hr</span>
                        </div>
                        <div class=""card-text pt-3 onetime-text"">
                            <p><img src=""../image/price_checkbox.png"">Lower Prices</p>

                            <p><img src=""../image/price_checkbox.png"">Easy Online & Secure Payment</p>

                            <p><img src=""../image/price_checkbox.png"">Easy Amendment</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!--one time section ends-->
<!--Extra Services section starts-->
<section class=""mb-2"">
    <div class=""row justify-content-center flex-wrap"">
        <div class=""container col-lg-2 border-top justify-content-center extra-service"">
            <div class=""d-flex justify-content-center text-center extra-service-title""> Extra Services</div>
     ");
            WriteLiteral(@"       <div class=""d-flex justify-content-center"">
                <hr class=""line1"">
                <img src=""../image/star.png"" class=""star"">
                <hr class=""line2"">
            </div>
            <div class=""container d-flex flex-wrap mt-2 me-5"">

                <!--container-1-->
                <div class=""card border border-0 text-center justify-content-center  mx-2 extraservicebox"">
                    <div class=""mx-auto"">
                        <div class=""border border-2 rounded-circle text-center acessimg"">
                            <img class=""card-img-top"" src=""../image/cabinet.png"" alt=""Card image"">
                        </div>
                    </div>
                    <div class=""card-body text-center extraservice-body"">
                        <h5 class=""card-title"">Inside cabinets</h5>
                        <p class=""card-text""><strong>30 minutes</strong></p>
                    </div>
                </div>

                <!--container-2-->
   ");
            WriteLiteral(@"             <div class=""card border border-0 text-center justify-content-center  mx-2 extraservicebox"">
                    <div class=""mx-auto"">
                        <div class=""border border-2 rounded-circle text-center acessimg"">
                            <img class=""card-img-top"" src=""../image/fridge.png"" alt=""Card image"">
                        </div>
                    </div>
                    <div class=""card-body text-center extraservice-body"">
                        <h5 class=""card-title"">Inside fridge</h5>
                        <p class=""card-text""><strong>30 minutes</strong></p>
                    </div>
                </div>

                <!--container-3-->
                <div class=""card border border-0 text-center justify-content-center  mx-2 extraservicebox"">
                    <div class=""mx-auto"">
                        <div class=""border border-2 rounded-circle text-center acessimg"">
                            <img class=""card-img-top"" src=""../image/oven");
            WriteLiteral(@".png"" alt=""Card image"">
                        </div>
                    </div>
                    <div class=""card-body text-center extraservice-body"">
                        <h5 class=""card-title"">Inside oven</h5>
                        <p class=""card-text""><strong>30 minutes</strong></p>
                    </div>
                </div>

                <!--container-4-->
                <div class=""card border border-0 text-center justify-content-center  mx-2 extraservicebox"">
                    <div class=""mx-auto"">
                        <div class=""border border-2 rounded-circle text-center acessimg"">
                            <img class=""card-img-top"" src=""../image/laundry.png"" alt=""Card image"">
                        </div>
                    </div>
                    <div class=""card-body text-center extraservice-body"">
                        <h5 class=""card-title"">Laundry wash & dry</h5>
                        <p class=""card-text""><strong>30 minutes</strong></p>
   ");
            WriteLiteral(@"                 </div>
                </div>

                <!--container-5-->
                <div class=""card border border-0 text-center justify-content-center  mx-2 extraservicebox"">
                    <div class=""mx-auto"">
                        <div class=""border border-2 rounded-circle text-center acessimg"">
                            <img class=""card-img-top"" src=""../image/window.png"" alt=""Card image"">
                        </div>
                    </div>
                    <div class=""card-body text-center extraservice-body"">
                        <h5 class=""card-title"">Interior windows</h5>
                        <p class=""card-text""><strong>30 minutes</strong></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!--Extra Services section ends-->
<!--what we include in cleaning section starts-->
<section>
    <div class=""container bg-light"">
        <div class=""d-flex justify-content-center text-center pr");
            WriteLiteral(@"ice_title"">
            What we include in cleaning
        </div>

        <div class=""d-flex justify-content-center"">
            <hr class=""line1"">
            <img src=""../image/star.png"" class=""star"">
            <hr class=""line2"">
        </div>

        <div class=""container includecleaningbox"">
            <div class=""row justify-content-center d-flex align-items-stretch"">
                <!---c1-->
                <div class=""col-lg-3 c1"">
                    <img src=""../image/bedroom.png"">
                    <p>Bedroom & Livingroom</p>
                    <div class=""d-flex mx-0 c1-text"">
                        <a href=""#demo1"" class=""p-0 m-0"" data-bs-toggle=""collapse"">
                            <img src=""../image/vector-smart-object-copy.png"">
                        </a>
                        <p>
                            Dust
                            all
                            accessible surfaces
                        </p>
                    </div>
  ");
            WriteLiteral(@"                  <div class=""d-flex mx-0 c1-text"">
                        <a href=""#demo1"" class=""p-0 m-0"" data-bs-toggle=""collapse"">
                            <img src=""../image/vector-smart-object-copy.png"">
                        </a>
                        <p>
                            Wipe
                            down
                            all
                            mirrors & glass fixtures
                        </p>
                    </div>
                    <div class=""d-flex mx-0 c1-text"">
                        <a href=""#demo1"" class=""p-0 m-0"" data-bs-toggle=""collapse"">
                            <img src=""../image/vector-smart-object-copy.png"">
                        </a>
                        <p>
                            Clean
                            all
                            floor surfaces
                        </p>
                    </div>
                    <div class=""d-flex mx-0 c1-text"">
                        <a href=");
            WriteLiteral(@"""#demo1"" class=""p-0 m-0"" data-bs-toggle=""collapse"">
                            <img src=""../image/vector-smart-object-copy.png"">
                        </a>
                        <p>
                            Take
                            out
                            garbage & recycling
                        </p>
                    </div>

                </div>
                <!--2-->
                <div class=""col-lg-3 c1"">
                    <img src=""../image/bathroom.png"">
                    <p>Bathrooms</p>
                    <div class=""d-flex mx-0 c1-text"">
                        <a href=""#demo1"" class=""p-0 m-0"" data-bs-toggle=""collapse"">
                            <img src=""../image/vector-smart-object-copy.png"">
                        </a>
                        <p>
                            Dust
                            all
                            accessible surfaces
                        </p>
                    </div>
                   ");
            WriteLiteral(@" <div class=""d-flex mx-0 c1-text"">
                        <a href=""#demo1"" class=""p-0 m-0"" data-bs-toggle=""collapse"">
                            <img src=""../image/vector-smart-object-copy.png"">
                        </a>
                        <p>
                            Wash
                            &
                            sanitize the toilet,shower,tub,sink
                        </p>
                    </div>
                    <div class=""d-flex mx-0 c1-text"">
                        <a href=""#demo1"" class=""p-0 m-0"" data-bs-toggle=""collapse"">
                            <img src=""../image/vector-smart-object-copy.png"">
                        </a>
                        <p>
                            Wipe
                            down all
                            mirrors & glass fixtures
                        </p>
                    </div>
                    <div class=""d-flex mx-0 c1-text"">
                        <a href=""#demo1"" class=""p-0 m-0"" dat");
            WriteLiteral(@"a-bs-toggle=""collapse"">
                            <img src=""../image/vector-smart-object-copy.png"">
                        </a>
                        <p>
                            Clean
                            all
                            floor surfaces
                        </p>
                    </div>
                    <div class=""d-flex mx-0 c1-text"">
                        <a href=""#demo1"" class=""p-0 m-0"" data-bs-toggle=""collapse"">
                            <img src=""../image/vector-smart-object-copy.png"">
                        </a>
                        <p>
                            Take
                            out
                            garbage & recycling
                        </p>
                    </div>
                </div>

                <!--3-->
                <div class=""col-lg-3 c1"">
                    <img src=""../image/kitchen.png"">
                    <p>Kitchen</p>
                    <div class=""d-flex mx-0 c1-text"">
            WriteLiteral(@"
                        <a href=""#demo1"" class=""p-0 m-0"" data-bs-toggle=""collapse"">
                            <img src=""../image/vector-smart-object-copy.png"">
                        </a>
                        <p>
                            Dust all
                            accessible surfaces
                        </p>
                    </div>
                    <div class=""d-flex mx-0 c1-text"">
                        <a href=""#demo1"" class=""p-0 m-0"" data-bs-toggle=""collapse"">
                            <img src=""../image/vector-smart-object-copy.png"">
                        </a>
                        <p>
                            Empty sink &
                            loadup dishwasher
                        </p>
                    </div>
                    <div class=""d-flex mx-0 c1-text"">
                        <a href=""#demo1"" class=""p-0 m-0"" data-bs-toggle=""collapse"">
                            <img src=""../image/vector-smart-object-copy.png"">
           ");
            WriteLiteral(@"             </a>
                        <p>
                            Wipe down all
                            mirrors & glass fixtures
                        </p>
                    </div>
                    <div class=""d-flex mx-0 c1-text"">
                        <a href=""#demo1"" class=""p-0 m-0"" data-bs-toggle=""collapse"">
                            <img src=""../image/vector-smart-object-copy.png"">
                        </a>
                        <p>
                            Clean all
                            floor surfaces
                        </p>
                    </div>
                    <div class=""d-flex mx-0 c1-text"">
                        <a href=""#demo1"" class=""p-0 m-0"" data-bs-toggle=""collapse"">
                            <img src=""../image/vector-smart-object-copy.png"">
                        </a>
                        <p>
                            Take out
                            garbage & recycling
                        </p>
       ");
            WriteLiteral(@"             </div>

                </div>
            </div>
        </div>
    </div>
</section>

<!--what we include in cleaning section ends-->
<!--why helperland section starts-->
<section style=""position: relative;"">
    <div calss=""container"">
        <h3 class=""text-center pt-5 pb-0 mb-0 why-helperland-title"">Why Helperland</h3>
        <div class=""d-flex justify-content-center  "" style=""margin-top: 0rem;"">
            <hr class=""line1"">
            <img src=""../image/star.png"" class=""star"">
            <hr class=""line2"">
        </div>
    </div>

    <!--  content-->
    <!-- c-1 -->
    <div class=""container mt-5"" style=""position: relative;"">
        <div class=""row d-flex flex-wrap justify-content-center"">
            <div class=""col-lg-4 float-end right-content"">
                <p class=""p1"">
                    Experienced and vetted
                    professionals
                </p>
                <P class=""p2"">
                    dominate the industry in s");
            WriteLiteral(@"cale and scope with
                    an
                    adaptable, extensive network that consistently delivers exceptional results.
                </P>
                <p class=""p1"">Dedicated customer service</p>
                <P class=""p2"">
                    to our customers and are guided in all we do by their
                    needs. The
                    team is always happy to support you and offer all the information. you need.
                </P>
            </div>
            <!-- c2 -->
            <div class=""col-lg-4 text-center"">
                <img src=""../image/best_img.png"" alt=""badge"">
            </div>

            <!-- c-3 -->

            <div class=""col-lg-4 left-content"">
                <p class=""p21"">Every cleaning is insured</p>
                <P class=""p22"">
                    and seek to provide
                    exceptional service and engage in proactive
                    behavior. We‘d be happy to clean your homes.
                ");
            WriteLiteral(@"</P>
                <p class=""p21"">Secure online payment</p>
                <P class=""p22"">
                    Payment is processed
                    securely online. Customers pay safely
                    online and manage the booking.
                </P>
            </div>
        </div>
    </div>
</section>
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