using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject_Backend.Data;
using ShareModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProduct _product;

        public ProductController(IProduct product)
        {
            _product = product;
        }

        [HttpGet]
        public async Task<ActionResult<ProductShare>> Get()
        {
            var product = await _product.GetAllAsync();
            return Ok(product);
        }
        
        //[HttpPost]

        //public async Task<ActionResult> Create (ProductFromCategory share)
        //{
            
        //}

    }
}
