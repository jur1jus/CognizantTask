using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.ViewModels
{
    public class TopUsersViewModel
    {
		public string Nickname { get; set; }

		public int CountOfSuccessfullSubmissions { get; set; }

		public string SovedTasks { get; set; }
    }
}
