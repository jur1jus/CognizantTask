#pragma checksum "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\Submission\SubmissionCompile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2f19abe59b09b630aaa67d734e411154886362d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Submission_SubmissionCompile), @"mvc.1.0.view", @"/Views/Submission/SubmissionCompile.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Submission/SubmissionCompile.cshtml", typeof(AspNetCore.Views_Submission_SubmissionCompile))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f19abe59b09b630aaa67d734e411154886362d1", @"/Views/Submission/SubmissionCompile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8af716e6553a8e043cdb93f77500b4ceabd6b6bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Submission_SubmissionCompile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CompilationResult>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(26, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\Submission\SubmissionCompile.cshtml"
 if (Model != null && Model.IsCopileSuccessful) {

	var failedTestCases = Model.TestCases.Where(m => m.IsTestPassed == false).Count();
	var totalTestCases = Model.TestCases.Count();

	if (totalTestCases == failedTestCases) {

#line default
#line hidden
            BeginContext(259, 114, true);
            WriteLiteral("\t\t<div class=\"compilation-result-fail-wrapper\">\r\n\t\t\t<p class=\"compilation-status fail\">Wrong Answer :(</p>\r\n\t\t\t<p>");
            EndContext();
            BeginContext(374, 15, false);
#line 11 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\Submission\SubmissionCompile.cshtml"
          Write(failedTestCases);

#line default
#line hidden
            EndContext();
            BeginContext(389, 3, true);
            WriteLiteral(" / ");
            EndContext();
            BeginContext(393, 14, false);
#line 11 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\Submission\SubmissionCompile.cshtml"
                             Write(totalTestCases);

#line default
#line hidden
            EndContext();
            BeginContext(407, 33, true);
            WriteLiteral(" test case failed</p>\r\n\t\t</div>\r\n");
            EndContext();
#line 13 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\Submission\SubmissionCompile.cshtml"
	} else {

#line default
#line hidden
            BeginContext(451, 245, true);
            WriteLiteral("\t\t<div class=\"compilation-result-success-wrapper\">\r\n\t\t\t<p class=\"compilation-status success\">Congratulations !</p>\r\n\t\t\t<p>You have passed the sample test cases. Click the submit button to run your code against all the test cases.</p>\r\n\t\t</div>\r\n");
            EndContext();
#line 18 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\Submission\SubmissionCompile.cshtml"
	}



	foreach (var testCase in Model.TestCases) {
		var color = Model.UserSubmissionResult == testCase.ExpectedResult ? "test-passed" : "test-failed";


#line default
#line hidden
            BeginContext(856, 75, true);
            WriteLiteral("\t\t<div class=\"card result-card\">\r\n\r\n\t\t\t<div class=\"card-header\">\r\n\t\t\t\t<span");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 931, "\"", 945, 1);
#line 28 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\Submission\SubmissionCompile.cshtml"
WriteAttributeValue("", 939, color, 939, 6, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(946, 18, true);
            WriteLiteral(">Sample Test Case ");
            EndContext();
            BeginContext(965, 14, false);
#line 28 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\Submission\SubmissionCompile.cshtml"
                                                 Write(testCase.Index);

#line default
#line hidden
            EndContext();
            BeginContext(979, 156, true);
            WriteLiteral(" <i class=\"fas fa-check-circle\"></i></span>\r\n\t\t\t</div>\r\n\t\t\t<div class=\"card-body\">\r\n\t\t\t\t<p class=\"label\">Input</p>\r\n\t\t\t\t<div class=\"compile-message\">\r\n\t\t\t\t\t");
            EndContext();
            BeginContext(1136, 14, false);
#line 33 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\Submission\SubmissionCompile.cshtml"
               Write(testCase.Input);

#line default
#line hidden
            EndContext();
            BeginContext(1150, 92, true);
            WriteLiteral("\r\n\t\t\t\t</div>\r\n\t\t\t\t<p class=\"label\">Your output</p>\r\n\t\t\t\t<div class=\"compile-message\">\r\n\t\t\t\t\t");
            EndContext();
            BeginContext(1243, 26, false);
#line 37 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\Submission\SubmissionCompile.cshtml"
               Write(Model.UserSubmissionResult);

#line default
#line hidden
            EndContext();
            BeginContext(1269, 96, true);
            WriteLiteral("\r\n\t\t\t\t</div>\r\n\t\t\t\t<p class=\"label\">Expected output</p>\r\n\t\t\t\t<div class=\"compile-message\">\r\n\t\t\t\t\t");
            EndContext();
            BeginContext(1366, 23, false);
#line 41 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\Submission\SubmissionCompile.cshtml"
               Write(testCase.ExpectedResult);

#line default
#line hidden
            EndContext();
            BeginContext(1389, 35, true);
            WriteLiteral("\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n");
            EndContext();
#line 45 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\Submission\SubmissionCompile.cshtml"
	}


} else {

#line default
#line hidden
            BeginContext(1442, 185, true);
            WriteLiteral("\t<div class=\"compilation-result-fail-wrapper\">\r\n\t\t<p class=\"compilation-status fail\">Compilation fail :(</p>\r\n\t\t<p>Check the compiler output, fix the error and try again.</p>\r\n\t</div>\r\n");
            EndContext();
            BeginContext(1629, 123, true);
            WriteLiteral("\t<div class=\"card fail-card\">\r\n\t\t<div class=\"card-body\">\r\n\t\t\t<p>Compile Message</p>\r\n\t\t\t<div class=\"compile-message\">\r\n\t\t\t\t");
            EndContext();
            BeginContext(1753, 28, false);
#line 58 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\Submission\SubmissionCompile.cshtml"
           Write(Model.CompilationFailMessage);

#line default
#line hidden
            EndContext();
            BeginContext(1781, 32, true);
            WriteLiteral("\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n");
            EndContext();
#line 62 "C:\Users\Admin\Desktop\GognizantTask\GognizantTask\Views\Submission\SubmissionCompile.cshtml"

}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CompilationResult> Html { get; private set; }
    }
}
#pragma warning restore 1591