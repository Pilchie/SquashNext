using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloMvc.Data;
using Microsoft.AspNetCore.Mvc;
using Octokit;

namespace HelloMvc
{
    public class HomeController : Controller
    {
        private readonly ApiConnection _apiConnection;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ApiConnection apiConnection, ApplicationDbContext dbContext)
        {
            _apiConnection = apiConnection;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var issues = _dbContext.Issues.OrderBy(i => i.Milestone).ThenBy(i => i.Priority).ToList();
            return View(issues);
        }

        [HttpGet]
        public async Task<IActionResult> AddNew()
        {
            var request = new RepositoryIssueRequest
            {
                State = ItemState.Open,
                SortDirection = SortDirection.Ascending,
                SortProperty = IssueSort.Created,
            };
            request.Labels.Add("Area-IDE");

            var parameters = request.ToParametersDictionary();
            parameters["per_page"] = "1000";
            var ghIssues = await _apiConnection.GetAll<Issue>(ApiUrls.Issues("dotnet", "roslyn"), parameters);
            var localIssues = new HashSet<int>(_dbContext.Issues.Select(i => i.GitHubIssueNumber));

            foreach (var i in ghIssues)
            {
                if (!localIssues.Contains(i.Number))
                {
                    _dbContext.Issues.Add(new Models.Issue
                    {
                        GitHubIssueNumber =i.Number,
                        Title = i.Title,
                        HtmlUrl = i.HtmlUrl.OriginalString,
                    });
                }
            }
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Error() => View();
    }
}