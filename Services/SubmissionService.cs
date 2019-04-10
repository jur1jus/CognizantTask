using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dal;
using ViewModels = Dal.ViewModels;
using Dal.Utils;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Services.Utils;
using Models = Dal.Models;

namespace Services
{
	public interface ISubmissionService : IBaseService
	{
		Task<JDoodleResult> GetJDoodleResult(string script);

		Task<List<ViewModels.TestCase>> GetTestCases(int taskId, string userSubmissionResult);

		Task SaveUserSubmission(ViewModels.SubmissionViewModel submission);

		Task<List<ViewModels.TopUsersViewModel>> GetTopUsers();
	}

	public class SubmissionService : BaseService, ISubmissionService
	{
		private readonly string _basePath = AppDomain.CurrentDomain.BaseDirectory;
		private readonly IConfiguration _configuration;
		public SubmissionService(CognizantDataContext dbContext, IConfiguration configuration)
			: base(dbContext)
		{
			_configuration = configuration;
		}

		public async Task<JDoodleResult> GetJDoodleResult(string script)
		{
			var jDoodleUrl = _configuration.GetValue<string>("AppSettings:jdoodleApiUrl");
			var jDoodleClientId = _configuration.GetValue<string>("AppSettings:jdoodleClientId");
			var jDoodleClientSecret = _configuration.GetValue<string>("AppSettings:jdoodleClientSecret");

			var jDoodleRequestBody = new JDoodleRequest(script, jDoodleClientId, jDoodleClientSecret);

			using (HttpClient httpClient = new HttpClient()) {
				using (var request = new HttpRequestMessage(HttpMethod.Post, jDoodleUrl + "execute")) {
					var json = JsonConvert.SerializeObject(jDoodleRequestBody);
					using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json")) {
						request.Content = stringContent;

						using (var response = await httpClient
							.SendAsync(request)
							.ConfigureAwait(false)) {
							response.EnsureSuccessStatusCode();
							var responseContent = await response.Content.ReadAsStringAsync();
							return JsonConvert.DeserializeObject<JDoodleResult>(responseContent);
						}
					}
				}
			}
		}

		public async Task<List<ViewModels.TestCase>> GetTestCases(int taskId, string userSubmissionResult)
		{
			var testCasesResult = new List<ViewModels.TestCase>();
			var expectedResultFiles = await (from testCases in _dbContext.TestCases
						 where testCases.TaskId == taskId
						 select new {
							 ResultPath =  testCases.Path,
							 IntputPath = testCases.InputFilePath
						 }).ToListAsync();

			for (int i = 0; i < expectedResultFiles.Count; i++) {
				var resultContent = File.ReadAllText(Path.Combine(_basePath, expectedResultFiles[i].ResultPath));
				var intpuContent = File.ReadAllText(Path.Combine(_basePath, expectedResultFiles[i].IntputPath));
				testCasesResult.Add(new ViewModels.TestCase {
					ExpectedResult = resultContent.Trim(),
					Index = i + 1,
					Input = intpuContent.Trim()
				});
			}
			return RunTests(testCasesResult, userSubmissionResult);
		}

		public async Task SaveUserSubmission(ViewModels.SubmissionViewModel submission)
		{
			var submitionFilename = Path.Combine("UserSubmissions", GenerateFilename(submission.Nickname, submission.Task));

			File.WriteAllLines(Path.Combine(_basePath, submitionFilename), submission.Submission.Split("\n"));

			var userSubmission = new Models.UserSubmission {
				IsSuccess = submission.IsSuccess,
				Nickname = submission.Nickname,
				UserSubmissionFilePath = submitionFilename,
				TaskId = submission.Task
			};

			_dbContext.UsersSubmissions.Add(userSubmission);
			await _dbContext.SaveChangesAsync();
			
		}

		public async Task<List<ViewModels.TopUsersViewModel>> GetTopUsers()
		{
			var topUsersList = await (from submissions in _dbContext.UsersSubmissions
										group submissions by submissions.Nickname into g
										let countOfSuccessfullSubmissions = g.Count(m => m.IsSuccess == true)
										orderby countOfSuccessfullSubmissions descending
										select new ViewModels.TopUsersViewModel {
											Nickname = g.Key,
											CountOfSuccessfullSubmissions = countOfSuccessfullSubmissions
										}).ToListAsync();
			topUsersList = topUsersList.Take(5).ToList();
			
			return topUsersList;
		}

		private List<ViewModels.TestCase> RunTests(List<ViewModels.TestCase> testCases, string userSubmissionResult)
		{
			for (int i = 0; i < testCases.Count; i++) {
				if (testCases[i].ExpectedResult == userSubmissionResult) {
					testCases[i].IsTestPassed = true;
				}
			}

			return testCases;
		}

		private string GenerateFilename(string nickname, int taskId)
		{
			return $"{DateTime.Now.LongDateTime()}_{nickname}_{taskId}.txt";
		}

	}
}
