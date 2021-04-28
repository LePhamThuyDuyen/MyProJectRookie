using CustomerSite.SerVices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerSite.Controllers
{
    public class RatingController : Controller
    {
        private readonly IProductApiClient _productApiClient;

        public RatingController(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }

        [Authorize]
        public async Task<IActionResult> Voting(int ProductID, int rating)
        {
            string uri_redirect = Request.Headers["Referer"].ToString();
            var result = await _productApiClient.Rating(ProductID, rating);

            if (result is false)
            {
                return Content("false");
            }
            return Redirect(uri_redirect);
        }
    }
}
