using MyProject_Backend.Models;
using ShareModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject_Backend.Controllers
{
    public  interface IProduct
    {
        Task<Product> CreateAsync(Product pro);

        Task<Product> DeleteAsync(int id);

        Task<IEnumerable<ProductShare>> GetAllAsync();

        Task<IEnumerable<ProductFromCategory>> GetByCategoryAsync(string categoryName);

        Task<Product> UpdateAsync(int id, Product pro);

        Task<ProductFromCategory> GetByIdAsync(int id);
    }
}
