using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Octokit;

namespace HelloMvc
{
    public class HomeController : Controller
    {
        private readonly ApiConnection _apiConnection;

        public HomeController(ApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }

        public async Task<IActionResult> Index()
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
            var issues = await _apiConnection.GetAll<Issue>(ApiUrls.Issues("dotnet", "roslyn"), parameters);
            return View(issues);
        }

        public IActionResult Error() => View();
    }
}