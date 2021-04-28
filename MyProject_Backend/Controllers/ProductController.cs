using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject_Backend.InterfaceService;
using MyProject_Backend.Models;
using ShareModel;
using System;
using System.IO;
using System.Net.Http.Headers;
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
        public async Task<ActionResult<ProductShare>> Create([FromForm] ProductCreateRequest productShare)
        {
         
            var result = await _product.CreateAsync(productShare);
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
        public async Task<ActionResult> Update(int id, [FromForm] ProductCreateRequest model)
        {
            var product = await _product.FindByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var result = await _product.UpdateAsync(id, model);
            return Ok(result);
        }

    }
}
