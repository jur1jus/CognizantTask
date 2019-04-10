using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dal.ViewModels
{
    public class SubmissionViewModel
    {
		public string Nickname { get; set; }

		public int Task { get; set; }

		public string Submission { get; set; }

		public bool IsSuccess { get; set; }
	}
}
