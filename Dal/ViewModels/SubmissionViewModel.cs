using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dal.ViewModels
{
    public class SubmissionViewModel
    {
		[Required(ErrorMessage = "Nicname is required.")]
		public string Nickname { get; set; }

		[Required(ErrorMessage = "Select task.")]
		public int Task { get; set; }

		public string Submission { get; set; }
	}
}
