using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject_Backend.Data;
using MyProject_Backend.Models;
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
        [AllowAnonymous]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _product.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("category={categoryName}")]
        [AllowAnonymous]
        public async Task<ActionResult> GetByCategory(string categoryName)
        {
            var results = await _product.GetByCategoryAsync(categoryName);
            return Ok(results);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Create( ProductShare productShare)
        {
            Product pro = new Product();
            pro.Name = productShare.ProductName;
            pro.Description = productShare.Description;
            pro.CategoryId = productShare.CategoryID;
            pro.Price = productShare.Price;
            pro.Image = productShare.Image;

            var result = await _product.CreateAsync(pro);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _product.DeleteAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(int id, [FromForm] ProductShare model)
        {
            var product = await _product.FindByIdAsync(id);
            product.Name = model.ProductName;
            product.Description = model.Description;
            product.Price = model.Price;
            product.CategoryId = model.CategoryID   ;
            var result = await _product.UpdateAsync(id, product);
            return Ok(result);
        }
        }
}
