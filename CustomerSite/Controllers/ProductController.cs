using CustomerSite.SerVices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using System.Collections.Generic;
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

        public async Task<IActionResult> addProductToCart(int id, int qty)
        {
            List<CartItemShare> cart = HttpContext.Session.Get<List<CartItemShare>>("UserCart");
            if (cart == null)
            {
                cart = new List<CartItemShare>();
            }

            foreach (var item in cart)
            {
                if (item.ProductId == id)
                {
                    item.Quality += qty;
                    HttpContext.Session.Set<List<CartItemShare>>("UserCart", cart);
                    Task.WaitAll(Task.Delay(2000));
                    return RedirectToAction("Details", "Product", new { id = id });
                }
            }

            var product = await _productApiClient.GetProductById(id);
            var productItem = new CartItemShare
            {
                ProductId = (int)product.ProductID,
                ProductName = product.ProductName,
                Price = (decimal)product.Price,
                Quality = qty,
                Image = product.Image
            };

            cart.Add(productItem);
            HttpContext.Session.Set<List<CartItemShare>>("UserCart", cart);

            Task.WaitAll(Task.Delay(2000));
            return RedirectToAction("Details", "Product", new { id = id });
        }

    }
}
