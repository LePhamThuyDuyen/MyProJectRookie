using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerSite.SerVices
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

        }
        public async Task<IList<ProductShare>> GetProducts()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44311/Product");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<ProductShare>>();
        }

        public async Task<ProductShare> GetProductById(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44311/Product/"+id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ProductShare>();
        }
    }
}
