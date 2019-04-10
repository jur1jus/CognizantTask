using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Dal.Utils
{
    public class JDoodleResult
    {
		public string output { get; set; }

		public HttpStatusCode? statusCode { get; set; }

		public double? memory { get; set; }

		public double? cpuTime { get; set; }
    }
}
