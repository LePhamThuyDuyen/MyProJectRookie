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


        [HttpGet]
        [Route("{id}")]
     //   [AllowAnonymous]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _product.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("category={categoryName}")]
     //   [AllowAnonymous]
        public async Task<ActionResult> GetByCategory(string categoryName)
        {
            var results = await _product.GetByCategoryAsync(categoryName);
            return Ok(results);
        }

    }
}
