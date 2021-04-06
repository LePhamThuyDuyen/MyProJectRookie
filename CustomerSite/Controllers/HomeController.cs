using CustomerSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly ICategoryApiClient _apiClient;

        public HomeController(ILogger<HomeController> logger/*, ICategoryApiClient apiClient*/)
        {
            _logger = logger;
            //_apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            //var Catrgory = await _apiClient.GetCategories();
            //return View(Catrgory);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
