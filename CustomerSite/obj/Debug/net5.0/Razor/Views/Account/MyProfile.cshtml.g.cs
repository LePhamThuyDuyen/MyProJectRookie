#pragma checksum "C:\Users\LeDuyen\Documents\MyProJectRookie\CustomerSite\Views\Account\MyProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f56e5b81279a5912246079d02b8aac362a26b344"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_MyProfile), @"mvc.1.0.view", @"/Views/Account/MyProfile.cshtml")]
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
#line 1 "C:\Users\LeDuyen\Documents\MyProJectRookie\CustomerSite\Views\_ViewImports.cshtml"
using CustomerSite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LeDuyen\Documents\MyProJectRookie\CustomerSite\Views\_ViewImports.cshtml"
using CustomerSite.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\LeDuyen\Documents\MyProJectRookie\CustomerSite\Views\Account\MyProfile.cshtml"
using Microsoft.AspNetCore.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LeDuyen\Documents\MyProJectRookie\CustomerSite\Views\Account\MyProfile.cshtml"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f56e5b81279a5912246079d02b8aac362a26b344", @"/Views/Account/MyProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"984cca509348be333376d43434e71edf9ec00b61", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_MyProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\LeDuyen\Documents\MyProJectRookie\CustomerSite\Views\Account\MyProfile.cshtml"
  
    ViewData["Title"] = "My profile";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2><a href=\"https://localhost:44311/Identity/Account/Manage\">My Account</a></h2>\r\n<br />\r\n<br />\r\n\r\n<h2>Claims</h2>\r\n\r\n<dl>\r\n");
#nullable restore
#line 17 "C:\Users\LeDuyen\Documents\MyProJectRookie\CustomerSite\Views\Account\MyProfile.cshtml"
     foreach (var claim in User.Claims)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dt>");
#nullable restore
#line 19 "C:\Users\LeDuyen\Documents\MyProJectRookie\CustomerSite\Views\Account\MyProfile.cshtml"
       Write(claim.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n        <dd>");
#nullable restore
#line 20 "C:\Users\LeDuyen\Documents\MyProJectRookie\CustomerSite\Views\Account\MyProfile.cshtml"
       Write(claim.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n");
#nullable restore
#line 21 "C:\Users\LeDuyen\Documents\MyProJectRookie\CustomerSite\Views\Account\MyProfile.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</dl>\r\n\r\n<h2>Properties</h2>\r\n\r\n<dl>\r\n");
#nullable restore
#line 27 "C:\Users\LeDuyen\Documents\MyProJectRookie\CustomerSite\Views\Account\MyProfile.cshtml"
     foreach (var prop in (await Context.AuthenticateAsync()).Properties.Items)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dt>");
#nullable restore
#line 29 "C:\Users\LeDuyen\Documents\MyProJectRookie\CustomerSite\Views\Account\MyProfile.cshtml"
       Write(prop.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n        <dd>");
#nullable restore
#line 30 "C:\Users\LeDuyen\Documents\MyProJectRookie\CustomerSite\Views\Account\MyProfile.cshtml"
       Write(prop.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n");
#nullable restore
#line 31 "C:\Users\LeDuyen\Documents\MyProJectRookie\CustomerSite\Views\Account\MyProfile.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</dl>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IConfiguration Configuration { get; private set; }
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
