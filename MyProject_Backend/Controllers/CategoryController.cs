using Microsoft.AspNetCore.Mvc;
using MyProject_Backend.Data;
using MyProject_Backend.Models;
using ShareModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize("Bearer")]
    public class CategoryController : ControllerBase
    {

        private readonly ICategory _category1;
      
        public CategoryController( ICategory category)
        {
            _category1 = category;
        }


        [HttpGet]
       // [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CategoryShare>>> Get()
        {
            var category = await _category1.GetAllAsync();
            return Ok(category);
        }

        [HttpGet("{id}")]
       // [AllowAnonymous]
        public async Task<ActionResult<CategoryShare>> GetCategory(int id)
        {
            var catagory = await _category1.getById(id);
            return Ok(catagory);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> PutCategory(int id, Category categories)
        {
            var category = await _category1.UpdateAsync(id,categories);
            if (category == null)
                return NotFound();
            return Ok(category);
            
        }


        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<CategoryShare>> PostCategory(Category categories)
        {
            var category = await _category1.CreateAsync(categories);
            return Ok(category);
        }

        [HttpDelete("{id}")]
      //  [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _category1.DeleteAsync (id);
            return Ok(category);
        }
    }
}
