#pragma checksum "C:\Users\HP\source\repos\Helperland_Project\Helperland_Project\Views\BookNow\Address.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "677dd7a460981c9319de982d4812bc5e4d6120f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BookNow_Address), @"mvc.1.0.view", @"/Views/BookNow/Address.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"677dd7a460981c9319de982d4812bc5e4d6120f1", @"/Views/BookNow/Address.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ee062c80a0e07be527800060e4d623f548c03c5", @"/Views/_ViewImports.cshtml")]
    public class Views_BookNow_Address : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Helperland_Project.Models.Data.UserAddress>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\HP\source\repos\Helperland_Project\Helperland_Project\Views\BookNow\Address.cshtml"
   Layout = null; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\Helperland_Project\Helperland_Project\Views\BookNow\Address.cshtml"
 foreach (var add in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"address row mb-3\">\n            <div class=\"col-lg-4 pt-4\">\n                <input type=\"radio\" name=\"address\" class=\"radio-btn\"");
            BeginWriteAttribute("value", " value=\"", 260, "\"", 312, 1);
#nullable restore
#line 7 "C:\Users\HP\source\repos\Helperland_Project\Helperland_Project\Views\BookNow\Address.cshtml"
WriteAttributeValue("", 268, Html.DisplayFor(modelItem => add.AddressId), 268, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n            </div>\n            <div class=\"col-lg-8\">\n                <p>\n                    Adress: ");
#nullable restore
#line 11 "C:\Users\HP\source\repos\Helperland_Project\Helperland_Project\Views\BookNow\Address.cshtml"
                       Write(Html.DisplayFor(modelItem => add.AddressLine1));

#line default
#line hidden
#nullable disable
            WriteLiteral(",");
#nullable restore
#line 11 "C:\Users\HP\source\repos\Helperland_Project\Helperland_Project\Views\BookNow\Address.cshtml"
                                                                       Write(Html.DisplayFor(modelItem => add.AddressLine2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    ");
#nullable restore
#line 12 "C:\Users\HP\source\repos\Helperland_Project\Helperland_Project\Views\BookNow\Address.cshtml"
               Write(Html.DisplayFor(modelItem => add.City));

#line default
#line hidden
#nullable disable
            WriteLiteral(",");
#nullable restore
#line 12 "C:\Users\HP\source\repos\Helperland_Project\Helperland_Project\Views\BookNow\Address.cshtml"
                                                       Write(Html.DisplayFor(modelItem => add.PostalCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </p>\n                <p>Phone Number:");
#nullable restore
#line 14 "C:\Users\HP\source\repos\Helperland_Project\Helperland_Project\Views\BookNow\Address.cshtml"
                           Write(Html.DisplayFor(modelItem => add.Mobile));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n            </div>\n        </div>\n");
#nullable restore
#line 17 "C:\Users\HP\source\repos\Helperland_Project\Helperland_Project\Views\BookNow\Address.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Helperland_Project.Models.Data.UserAddress>> Html { get; private set; }
    }
}
#pragma warning restore 1591
