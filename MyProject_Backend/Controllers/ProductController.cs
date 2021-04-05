using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject_Backend.Data;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<ProductShare>> Get()
        {
            var products = await _applicationDbContext.products.Select(x => new ProductShare
            {
                ProductID = x.Id,
                ProductName = x.Name,
                Price = x.Price,
                Description = x.Description,
               // Image = x.Image,

            }).ToListAsync();
            return Ok(products);
        }

    }
}
