#pragma checksum "E:\Projects\SoftServeProject\SoftServeProject\Views\ReaderStatistic\GetAllReadersStatistics.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8fb33caf64e34eb1d3ccab2229df54ba262a35dd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ReaderStatistic_GetAllReadersStatistics), @"mvc.1.0.view", @"/Views/ReaderStatistic/GetAllReadersStatistics.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8fb33caf64e34eb1d3ccab2229df54ba262a35dd", @"/Views/ReaderStatistic/GetAllReadersStatistics.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a4e10d9ac1245679b8a3ddf5585a32abbf6d4a5", @"/Views/_ViewImports.cshtml")]
    public class Views_ReaderStatistic_GetAllReadersStatistics : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AllReadersStat>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\nThis is average numbers of requests ");
#nullable restore
#line 4 "E:\Projects\SoftServeProject\SoftServeProject\Views\ReaderStatistic\GetAllReadersStatistics.cshtml"
                               Write(Model.avgNumOfRequest);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\nThis is average age ");
#nullable restore
#line 5 "E:\Projects\SoftServeProject\SoftServeProject\Views\ReaderStatistic\GetAllReadersStatistics.cshtml"
               Write(Model.avgAgeOfClient);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AllReadersStat> Html { get; private set; }
    }
}
#pragma warning restore 1591
