using Microsoft.EntityFrameworkCore;
using MyProject_Backend.Data;
using MyProject_Backend.Models;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyProject_Backend.Controllers
{
    public class ProductService : IProduct
    {
        private readonly ApplicationDbContext _applicationDb;

        public ProductService(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb;
        }
        public async Task<Product> CreateAsync(Product pro)
        {
            
            _applicationDb.Add(pro);
            await _applicationDb.SaveChangesAsync();
            return pro;
        }

        public async Task<Product> DeleteAsync(int id)
        {
            var product = await _applicationDb.products.FindAsync(id);
            if (product == null)
                return null;
            _applicationDb.products.Remove(product);
            await _applicationDb.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<ProductShare>> GetAllAsync()
        {
            var product = await _applicationDb.products.Include(p => p.category).Select(p =>
                new ProductShare
                {
                    ProductID = p.Id,
                    ProductName = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Image = p.Image
                }).ToListAsync();
            return product;
        }

        public async Task<IEnumerable<ProductFromCategory>> GetByCategoryAsync(string categoryName)
        {
            var products = await _applicationDb.products.Include(p => p.category).Where(p => p.category.CategoryName == categoryName).Select(p =>
                 new ProductFromCategory
                 {
                     CategoryId = p.Id,
                     ProductName = p.Name,
                     Description = p.Description,
                     Price = p.Price,
                    CategoryName  = p.category.CategoryName
                 }).ToListAsync();

            return products;
        }

        public async Task<ProductFromCategory> GetByIdAsync(int id)
        {
            var product = await _applicationDb.products.Include(p => p.category).Where(p => p.Id == id).Select(p =>
               new ProductFromCategory
               {
                   ProductId = p.Id,
                   ProductName = p.Name,
                   Description = p.Description,     
                   Price = p.Price,     
                   Img = p.Image,
                   CategoryName = p.category.CategoryName
               }).FirstOrDefaultAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(int id, Product pro)
        {
            var product = await _applicationDb.products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            product.Name = pro.Name;
            product.Description = pro.Description;
            product.Price = pro.Price;
            product.CategoryId = pro.CategoryId;
            await _applicationDb.SaveChangesAsync();
            return product;
        }

    }
}
