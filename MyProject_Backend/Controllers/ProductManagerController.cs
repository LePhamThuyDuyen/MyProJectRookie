using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject_Backend.Data;
using MyProject_Backend.Models;
using MyProject_Backend.ViewModel;

namespace MyProject_Backend.Controllers
{
    public class ProductManagerController :Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ProductManagerController(ApplicationDbContext applicationDbContext, IHostingEnvironment hostingEnvironment)
        {
            _applicationDbContext = applicationDbContext;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string p1 = null;
                if (model.ProductImage != null)
                {
                    using (var fs1 = model.ProductImage.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToString();
                    }
                }
                Product product = new Product
                {
                    Name = model.ProductName,
                    Price = model.Price,
                    Description = model.Description,
                    Image = p1,
                    CategoryId = model.CategoryID

                };
                _applicationDbContext.products.Add(product);
                await _applicationDbContext.SaveChangesAsync();
                return RedirectToAction("Index", "Home"); 
            }
            return View();
        }
    }
}
