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
    public class SubmissionController : Controller
    {
		private readonly ISubmissionService _submissionService;
		private readonly ITaskService _taskService;
		public SubmissionController(ISubmissionService submissionService, ITaskService taskService)
		{
			_submissionService = submissionService;
			_taskService = taskService;
		}
        // GET: /<controller>/
		[HttpGet]
		[Route("submission")]
        public async Task<IActionResult> Index()
        {
			ViewData["Tasks"] = await _taskService.GetTasks();
			return await Task.FromResult(View());
        }

		[HttpGet]
		[Route("task/temlate/{taskId:int?}")]
		public async Task<IActionResult> GetTaskTemplate(int? taskId)
		{
			if (taskId == null) {
				return BadRequest(new { message = "Task was not selected" });
			}

			var taskTempateUrl = await _taskService.GetTaskTemplatePath(taskId.Value);

			if (taskTempateUrl == null) {
				return Ok(new { taskTemplate = "" });
			} else {
				var taskTempate = await _taskService.GetTaskTemplate(taskTempateUrl);
				return Ok(new { taskTemplate = taskTempate });
			}
		}

		[HttpPost]
		[Route("submission/runcode")]
		public async Task<IActionResult> RunCode(ViewModels.RunSubmissionViewModel runSubmission) 
		{
			if (!ModelState.IsValid) {
				var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
				return BadRequest(new { errors = errors });
			}

			if (runSubmission.TaskId == null) {
				var viewModelResult = new ViewModels.CompilationResult {
					IsCopileSuccessful = false,
					CompilationFailMessage = "Select a task.",
					TestCases = null
				};
				return PartialView("SubmissionCompile", viewModelResult);
			}
			var result = await _submissionService.JDoodleResult(runSubmission.Code);

			if (result.output.Contains("Compilation failed")) {
				var viewModelResult = new ViewModels.CompilationResult {
					IsCopileSuccessful = false,
					CompilationFailMessage = result.output,
					TestCases = null
				};
				return PartialView("SubmissionCompile", viewModelResult);
			}

			var viewModel = new ViewModels.CompilationResult {
				IsCopileSuccessful = true,
				UserSubmissionResult = result.output.Trim()
			};

			viewModel.TestCases = await _submissionService.GetTestCases(runSubmission.TaskId.Value, result.output.Trim());

			return PartialView("SubmissionCompile", viewModel);
		}
		
    }
}
