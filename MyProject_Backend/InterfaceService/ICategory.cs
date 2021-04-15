using MyProject_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MyProject_Backend.Controllers
{
    public  interface ICategory
    {
        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category> getById(int id);

        Task<Category> CreateAsync(Category cate);

        Task<Category> UpdateAsync(int id, Category cate);

        Task<Category> DeleteAsync(int id);
    }
}
