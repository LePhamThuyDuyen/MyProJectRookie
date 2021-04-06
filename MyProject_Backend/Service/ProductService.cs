using MyProject_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyProject_Backend.Controllers
{
    public class ProductService : IProduct
    {
        public Task<Product> CreateAsync(Product pro)
        {
            throw new NotImplementedException();
        }

        public Task<Product> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetByCategoryAsync(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(int id, Product pro)
        {
            throw new NotImplementedException();
        }
    }
}
