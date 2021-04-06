using MyProject_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject_Backend.Controllers
{
  public  interface IProduct
    {
        Task<Product> CreateAsync(Product pro);

        Task<Product> DeleteAsync(int id);

        Task<IEnumerable<Product>> GetAllAsync();

        Task<IEnumerable<Product>> GetByCategoryAsync(string categoryName);

        Task<Product> UpdateAsync(int id, Product pro);
    }
}
