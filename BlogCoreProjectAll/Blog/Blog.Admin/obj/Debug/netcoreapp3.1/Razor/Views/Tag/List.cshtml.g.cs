#pragma checksum "D:\Bilge adam teams dosyalari\OneDrive_6_02.12.2021\MVC (.Net Core)\BlogCoreProject\BlogCoreProjectAll\Blog\Blog.Admin\Views\Tag\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71539f8bbbad7c9d9d0ddd7bd0479e929f5dabe1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tag_List), @"mvc.1.0.view", @"/Views/Tag/List.cshtml")]
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
#line 3 "D:\Bilge adam teams dosyalari\OneDrive_6_02.12.2021\MVC (.Net Core)\BlogCoreProject\BlogCoreProjectAll\Blog\Blog.Admin\Views\_ViewImports.cshtml"
using Blog.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71539f8bbbad7c9d9d0ddd7bd0479e929f5dabe1", @"/Views/Tag/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"345012540865350e582aee057fb983199e448d55", @"/Views/_ViewImports.cshtml")]
    public class Views_Tag_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<TagViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Bilge adam teams dosyalari\OneDrive_6_02.12.2021\MVC (.Net Core)\BlogCoreProject\BlogCoreProjectAll\Blog\Blog.Admin\Views\Tag\List.cshtml"
  
    ViewData["Title"] = "List";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Tag List</h1>\r\n\r\n");
#nullable restore
#line 9 "D:\Bilge adam teams dosyalari\OneDrive_6_02.12.2021\MVC (.Net Core)\BlogCoreProject\BlogCoreProjectAll\Blog\Blog.Admin\Views\Tag\List.cshtml"
 if (TempData["Message"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-info\">\r\n        ");
#nullable restore
#line 12 "D:\Bilge adam teams dosyalari\OneDrive_6_02.12.2021\MVC (.Net Core)\BlogCoreProject\BlogCoreProjectAll\Blog\Blog.Admin\Views\Tag\List.cshtml"
   Write(TempData["Message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 14 "D:\Bilge adam teams dosyalari\OneDrive_6_02.12.2021\MVC (.Net Core)\BlogCoreProject\BlogCoreProjectAll\Blog\Blog.Admin\Views\Tag\List.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table table-bordered\">\r\n    <thead>\r\n        <tr>\r\n            <th>Tag Adı</th>\r\n            <th>İşlemler</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 24 "D:\Bilge adam teams dosyalari\OneDrive_6_02.12.2021\MVC (.Net Core)\BlogCoreProject\BlogCoreProjectAll\Blog\Blog.Admin\Views\Tag\List.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 27 "D:\Bilge adam teams dosyalari\OneDrive_6_02.12.2021\MVC (.Net Core)\BlogCoreProject\BlogCoreProjectAll\Blog\Blog.Admin\Views\Tag\List.cshtml"
               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 574, "\"", 599, 2);
            WriteAttributeValue("", 581, "/tag/edit/", 581, 10, true);
#nullable restore
#line 29 "D:\Bilge adam teams dosyalari\OneDrive_6_02.12.2021\MVC (.Net Core)\BlogCoreProject\BlogCoreProjectAll\Blog\Blog.Admin\Views\Tag\List.cshtml"
WriteAttributeValue("", 591, item.Id, 591, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Düzenle</a> |\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 638, "\"", 665, 2);
            WriteAttributeValue("", 645, "/tag/delete/", 645, 12, true);
#nullable restore
#line 30 "D:\Bilge adam teams dosyalari\OneDrive_6_02.12.2021\MVC (.Net Core)\BlogCoreProject\BlogCoreProjectAll\Blog\Blog.Admin\Views\Tag\List.cshtml"
WriteAttributeValue("", 657, item.Id, 657, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Sil</a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 33 "D:\Bilge adam teams dosyalari\OneDrive_6_02.12.2021\MVC (.Net Core)\BlogCoreProject\BlogCoreProjectAll\Blog\Blog.Admin\Views\Tag\List.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<TagViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
