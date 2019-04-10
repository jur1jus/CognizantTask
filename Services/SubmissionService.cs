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

namespace Services
{
	public interface ISubmissionService : IBaseService
	{
		Task<JDoodleResult> JDoodleResult(string script);

		Task<List<ViewModels.TestCase>> GetTestCases(int taskId, string userSubmissionResult);
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

		public async Task<JDoodleResult> JDoodleResult(string script)
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
			return testCasesResult;
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
	}
}
