using CustomerSite.SerVices;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerSite.Controllers
{
    public class CartController : Controller
    {
        [Route("/cart")]
        public IActionResult Index()
        {
            var result = HttpContext.Session.Get<List<CartItemShare>>("UserCart");
            if (result == null)
            {
                result = new List<CartItemShare>();
            }
            return View(result);
        }

        public IActionResult Delete(int id)
        {
            List<CartItemShare> cart = HttpContext.Session.Get<List<CartItemShare>>("UserCart");

            var deleteMe = cart.Find(x => x.ProductId == id);

            cart.Remove(deleteMe);
            HttpContext.Session.Set("UserCart", cart);
            Task.WaitAll(Task.Delay(2000));
            return RedirectToAction("Index", "Cart");
        }

    }
}
