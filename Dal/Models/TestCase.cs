using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Models
{
	public class TestCase
	{
		public int Id { get; set; }

		public int TaskId { get; set; }

		public string Path { get; set; }

		public string InputFilePath { get; set; }
    }
}
