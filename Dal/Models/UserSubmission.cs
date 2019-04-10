using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Models
{
    public class UserSubmission
    {
		public int Id { get; set; }

		public string Nickname { get; set; }

		public string UserSubmissionFilePath { get; set; }

		public bool IsSuccess { get; set; }

		public int TaskId { get; set; }
	}
}
