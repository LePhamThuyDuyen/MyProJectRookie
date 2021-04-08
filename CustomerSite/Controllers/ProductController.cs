using CustomerSite.SerVices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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

    }
}
