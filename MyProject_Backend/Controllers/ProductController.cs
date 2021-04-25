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
        private readonly IStorageService _storageService;

        public ProductController(IProduct product, IStorageService storageService)
        {
            _product = product;
            _storageService = storageService;
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
            Product pro = new Product();
            pro.Name = productShare.ProductName;
            pro.Description = productShare.Description;
            pro.CategoryId = productShare.CategoryID;
            pro.Price = productShare.Price;

            if (productShare.ImageRequest != null)
            {
                pro.Image = await SaveFile(productShare.ImageRequest);
            }
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
        public async Task<ActionResult> Update(int id, [FromForm] ProductCreateRequest model)
        {
            var product = await _product.FindByIdAsync(id);
            product.Name = model.ProductName;
            product.Description = model.Description;
            product.Price = model.Price;
            product.CategoryId = model.CategoryID   ;
            var result = await _product.UpdateAsync(id, product);
            return Ok(result);
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
