using System;
using System.Collections.Generic;
using System.Text;
using Dal.Enums;
using Dal.ViewModels;

namespace Dal.ViewModels
{
    public class CompilationResult
    {
		public bool IsCopileSuccessful { get; set; }

		public List<TestCase> TestCases { get; set; }

		public string CompilationFailMessage { get; set; }

		public string UserSubmissionResult { get; set; }
    }
}
