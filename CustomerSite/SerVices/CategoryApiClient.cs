using ShareModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerSite.SerVices
{
    public class CategoryApiClient : ICategoryApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryApiClient (IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

        }
        public async Task<IList<CategoryShare>> GetCategories()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44311/api/Category");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<CategoryShare>>();
        }
    }

}
