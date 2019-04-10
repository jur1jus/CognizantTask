using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.ViewModels
{
    public class TestCase
    {
		public int Index { get; set; }

		public string Input { get; set; }

		public string ExpectedResult { get; set; }

		public bool IsTestPassed { get; set; }
    }
}
