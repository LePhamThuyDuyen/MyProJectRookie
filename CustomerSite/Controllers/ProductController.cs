using CustomerSite.SerVices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CustomerSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IConfiguration _configuration;


        public ProductController(IProductApiClient productApiClient, IConfiguration configuration)
        {
            _productApiClient = productApiClient;
            _configuration = configuration;

        }

        [Route("/Prodcut/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _productApiClient.GetProductById(id);
            return View(result);
        }

        [Route("/Prodcut/category{categoryName}")]
        public async Task<IActionResult> CategoryById(string categoryName)
        {
            var results = await _productApiClient.GetProductByCategory(categoryName);
            return View(results);

        }
    }
}
