#pragma checksum "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\Submission\TopUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4720f5ab534cf120b21bae1d2f18661111973708"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Submission_TopUsers), @"mvc.1.0.view", @"/Views/Submission/TopUsers.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Submission/TopUsers.cshtml", typeof(AspNetCore.Views_Submission_TopUsers))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\_ViewImports.cshtml"
using GognizantTask;

#line default
#line hidden
#line 2 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\_ViewImports.cshtml"
using GognizantTask.Models;

#line default
#line hidden
#line 3 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\_ViewImports.cshtml"
using Dal.ViewModels;

#line default
#line hidden
#line 1 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\Submission\TopUsers.cshtml"
using System.Collections.Generic;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4720f5ab534cf120b21bae1d2f18661111973708", @"/Views/Submission/TopUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8af716e6553a8e043cdb93f77500b4ceabd6b6bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Submission_TopUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<TopUsersViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(68, 207, true);
            WriteLiteral("\r\n<table class=\"table table-striped\">\r\n\t<thead>\r\n\t\t<tr>\r\n\t\t\t<th scope=\"col\">Nickname</th>\r\n\t\t\t<th scope=\"col\">Successful submissions</th>\r\n\t\t\t<th scope=\"col\">Solved tasks</th>\r\n\t\t</tr>\r\n\t</thead>\r\n\t<tbody>\r\n");
            EndContext();
#line 13 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\Submission\TopUsers.cshtml"
         foreach (var item in Model) {

#line default
#line hidden
            BeginContext(309, 17, true);
            WriteLiteral("\t\t\t<tr>\r\n\t\t\t\t<td>");
            EndContext();
            BeginContext(327, 13, false);
#line 15 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\Submission\TopUsers.cshtml"
               Write(item.Nickname);

#line default
#line hidden
            EndContext();
            BeginContext(340, 15, true);
            WriteLiteral("</td>\r\n\t\t\t\t<td>");
            EndContext();
            BeginContext(356, 34, false);
#line 16 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\Submission\TopUsers.cshtml"
               Write(item.CountOfSuccessfullSubmissions);

#line default
#line hidden
            EndContext();
            BeginContext(390, 15, true);
            WriteLiteral("</td>\r\n\t\t\t\t<td>");
            EndContext();
            BeginContext(406, 15, false);
#line 17 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\Submission\TopUsers.cshtml"
               Write(item.SovedTasks);

#line default
#line hidden
            EndContext();
            BeginContext(421, 17, true);
            WriteLiteral("</td>\r\n\t\t\t</tr>\r\n");
            EndContext();
#line 19 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\Submission\TopUsers.cshtml"
		}

#line default
#line hidden
            BeginContext(443, 19, true);
            WriteLiteral("\t</tbody>\r\n</table>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<TopUsersViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
