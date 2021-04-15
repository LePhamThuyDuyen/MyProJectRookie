using CustomerSite.SerVices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerSite.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
          private readonly IProductApiClient _productApiClient;

        public ProductViewComponent(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Pro = await _productApiClient.GetProducts();

            return View(Pro);
        }
    }
}
