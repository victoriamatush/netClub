#pragma checksum "E:\Projects\SoftServeProject\SoftServeProject\Views\Book\GetById.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "824acb484349d7148bcac26f91abf7089bf29773"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Book_GetById), @"mvc.1.0.view", @"/Views/Book/GetById.cshtml")]
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
#line 1 "E:\Projects\SoftServeProject\SoftServeProject\Views\_ViewImports.cshtml"
using SoftServeProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Projects\SoftServeProject\SoftServeProject\Views\_ViewImports.cshtml"
using SoftServeProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Projects\SoftServeProject\SoftServeProject\Views\_ViewImports.cshtml"
using SoftServeProject.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"824acb484349d7148bcac26f91abf7089bf29773", @"/Views/Book/GetById.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a4e10d9ac1245679b8a3ddf5585a32abbf6d4a5", @"/Views/_ViewImports.cshtml")]
    public class Views_Book_GetById : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<Bookauthor>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\nBook title is ");
#nullable restore
#line 3 "E:\Projects\SoftServeProject\SoftServeProject\Views\Book\GetById.cshtml"
         Write(Model.FirstOrDefault().Book.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\nBook authors are ");
#nullable restore
#line 4 "E:\Projects\SoftServeProject\SoftServeProject\Views\Book\GetById.cshtml"
                  foreach(var c in Model)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\Projects\SoftServeProject\SoftServeProject\Views\Book\GetById.cshtml"
           Write(c.Author.Name);

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\Projects\SoftServeProject\SoftServeProject\Views\Book\GetById.cshtml"
                          Write(c.Author.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n");
#nullable restore
#line 7 "E:\Projects\SoftServeProject\SoftServeProject\Views\Book\GetById.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ICollection<Bookauthor>> Html { get; private set; }
    }
}
#pragma warning restore 1591
