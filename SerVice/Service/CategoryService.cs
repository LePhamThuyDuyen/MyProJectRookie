using Microsoft.EntityFrameworkCore;
using MyProject_Backend.Data;
using MyProject_Backend.Models;
using SerVice.InterfaceService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerVice.Service
{
    public class CategoryService : ICategory

    {

        private readonly ApplicationDbContext _dbContext;

        public CategoryService (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> CreateAsync(Category cate)
        {
            _dbContext.Add(cate);
            await _dbContext.SaveChangesAsync();
            return cate;
                
        }
       
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var category = await _dbContext.categories.ToListAsync();
            return category; 
        }

       

        public async Task<Category> DeleteAsync(int id)
        {
            var category = await _dbContext.categories.FindAsync(id);
            if (category == null)
                return null;
            _dbContext.categories.Remove(category);
            await _dbContext.SaveChangesAsync();
            return category;

        }

        public async Task<Category> UpdateAsync(int id, Category cate)
        {
            var category = await _dbContext.categories.FindAsync(id);
            if (category == null)
                return null;
            category.CategoryName = cate.CategoryName;
            await _dbContext.SaveChangesAsync();
            return category;
        }
    }
}
