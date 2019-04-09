using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;
using ViewModels = Dal.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GognizantTask.Controllers
{
    public class TaskController : Controller
    {
		private readonly ITaskService _taskService;
		public TaskController(ITaskService taskService)
		{
			_taskService = taskService;
		}
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
			ViewData["Tasks"] = await _taskService.GetAll<ViewModels.Task>();
			return await Task.FromResult(View());
        }
    }
}
