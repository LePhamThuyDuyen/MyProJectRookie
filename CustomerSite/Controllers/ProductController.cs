using CustomerSite.SerVices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;

        public ProductController(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
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
