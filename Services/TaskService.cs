using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dal;
using ViewModels = Dal.ViewModels;
using Models = Dal.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Configuration;

namespace Services
{
	public interface ITaskService : IBaseService
	{
		Task<List<ViewModels.Task>> GetTasks();

		Task<string> GetTaskTemplatePath(int taskId);

		Task<string> GetTaskTemplate(string pathToFile);
	}
	public class TaskService : BaseService, ITaskService
	{
		private readonly string _path = AppDomain.CurrentDomain.BaseDirectory;
		public TaskService(CognizantDataContext dbContext) : base(dbContext)
		{
		}

		public async Task<List<ViewModels.Task>> GetTasks()
		{
			var result = await (from tasks in _dbContext.Tasks
								select new ViewModels.Task {
									Id = tasks.Id,
									Name = tasks.Name
								}).ToListAsync();

			return result;
		}

		public async Task<string> GetTaskTemplatePath(int taskId)
		{
			var result = await (from tasks in _dbContext.Tasks
								where tasks.Id == taskId
								select tasks.TemplatePath).FirstOrDefaultAsync();

			return result;
		}

		public async Task<string> GetTaskTemplate(string pathToFile)
		{
			pathToFile = Path.Combine(_path, pathToFile);

			string template = "";

			using (StreamReader reader = File.OpenText(pathToFile)) {
				template = await reader.ReadToEndAsync();
			}

			return await Task.FromResult(template);
		}


	}
}
