using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Models
{
    public class Task
    {
		public int Id { get; private set; }

		public string Name { get; private set; }

		public string TemplatePath { get; set; }
    }
}
