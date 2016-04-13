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