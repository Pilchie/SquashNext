using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Octokit;

namespace HelloMvc
{
    public class HomeController : Controller
    {
        private readonly GitHubClient _client;

        public HomeController(GitHubClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var request = new RepositoryIssueRequest();
            request.Labels.Add("Area-IDE");
            request.State = ItemState.Open;
            var issues = await _client.Issue.GetAllForRepository("dotnet", "roslyn", request);

            return View(issues);
        }

        public IActionResult Error() => View();
    }
}