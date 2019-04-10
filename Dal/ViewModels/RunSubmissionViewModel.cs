using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dal.ViewModels
{
    public class RunSubmissionViewModel
    {
		[Required(ErrorMessage = "Nicname is required.")]
		public string Nickname { get; set; }

		public string Code { get; set; }

		[Required(ErrorMessage = "Select a task.")]
		public int? TaskId { get; set; }
    }
}
