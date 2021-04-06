using MyProject_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerVice.InterfaceService
{
  public  interface ICategory
    {
        Task<IEnumerable<Category>> GetAllAsync();

      

        Task<Category> CreateAsync(Category cate);

        Task<Category> UpdateAsync(int id, Category cate);

        Task<Category> DeleteAsync(int id);
    }
}
