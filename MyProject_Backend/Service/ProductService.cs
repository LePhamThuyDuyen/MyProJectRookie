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
        public async Task<Product> CreateAsync(ProductCreateRequest model)
        {
            var product = new Product();
            product.Name = model.ProductName;
            product.Description = model.Description;
            product.Price = model.Price;
            product.CategoryId = model.CategoryID;
            product.Image = model.ImageRequest;
            _applicationDb.Add(product);
            await _applicationDb.SaveChangesAsync();
            return product;
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
                    CategoryID=p.CategoryId,
                    ProductName = p.Name,
                    CategoryName=p.category.CategoryName,
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
                     ProductName = p.Name,
                     Description = p.Description,
                     Price = p.Price,
                     Img=p.Image,
                    CategoryName  = p.category.CategoryName
                 }).ToListAsync();

            return products;
        }

        public async Task<ProductShare> GetByIdAsync(int id)
        {
            var product = await _applicationDb.products.Include(p => p.category).Where(p => p.Id == id).Select(p =>
               new ProductShare
               {
                   ProductID = p.Id,
                   CategoryID=p.CategoryId,
                   ProductName = p.Name,
                   Description = p.Description,     
                   Price = p.Price,     
                   Image = p.Image,
                   CategoryName = p.category.CategoryName
               }).FirstOrDefaultAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(int id, ProductCreateRequest model)
        {
            var product = await _applicationDb.products.FindAsync(id);
            product.Name = model.ProductName;
            product.Description = model.Description;
            product.Price = model.Price;
            product.CategoryId = model.CategoryID;
            product.Image = model.ImageRequest;
            await _applicationDb.SaveChangesAsync();
            return product;
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            var product = await _applicationDb.products.Include(p => p.category).Where(p => p.Id == id).FirstOrDefaultAsync();
            return product;
        }

    }
}
