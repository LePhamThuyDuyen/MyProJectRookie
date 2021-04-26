using MyProject_Backend.Models;
using ShareModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject_Backend.Controllers
{
    public  interface IProduct
    {
        Task<Product> CreateAsync(ProductCreateRequest model);

        Task<Product> DeleteAsync(int id);

        Task<IEnumerable<ProductShare>> GetAllAsync();

        Task<IEnumerable<ProductFromCategory>> GetByCategoryAsync(string categoryName);

        Task<Product> UpdateAsync(int id, ProductCreateRequest model);

        Task<ProductShare> GetByIdAsync(int id);

        Task<Product> FindByIdAsync(int id);



    }
}
