using ShareModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerSite.SerVices
{
    public interface IProductApiClient 
    {
        Task<IList<ProductShare>> GetProducts();

        Task<ProductShare> GetProductById(int id);

        Task<IList<ProductShare>> GetProductByCategory(string categoryName);
    }
}
