using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject_Backend.Data;
using MyProject_Backend.Models;
using ShareModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CategoryShare>>> Get()
        {
            return await _applicationDbContext.categories
                .Select(x => new CategoryShare { CategoryId = x.CategoryId, CategoryName= x.CategoryName})
                .ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<CategoryShare>> GetCategory(int id)
        {
            var brand = await _applicationDbContext.categories.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            var category = new CategoryShare
            {
                CategoryId = brand.CategoryId,
                CategoryName = brand.CategoryName
            };

            return category;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutCategory(int id, CategoryCreateRequest categoryCreateRequest)
        {
            var category = await _applicationDbContext.categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            category.CategoryName = categoryCreateRequest.Name;
            await _applicationDbContext.SaveChangesAsync();

            return NoContent();
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<CategoryShare>> PostCategory(CategoryCreateRequest brandCreateRequest)
        {
            var category = new Category
            {
                CategoryName = brandCreateRequest.Name
            };

            _applicationDbContext.categories.Add(category);
            await _applicationDbContext.SaveChangesAsync();

            return CreatedAtAction("GetBrand", new { id = category.CategoryId }, new CategoryShare { CategoryId = category.CategoryId, CategoryName = category.CategoryName });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _applicationDbContext.categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _applicationDbContext.categories.Remove(category);
            await _applicationDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
