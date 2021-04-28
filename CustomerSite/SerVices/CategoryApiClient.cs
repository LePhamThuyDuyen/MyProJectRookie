using Microsoft.Extensions.Configuration;
using ShareModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerSite.SerVices
{
    public class CategoryApiClient : ICategoryApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public CategoryApiClient (IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;

        }
        public async Task<IList<CategoryShare>> GetCategories()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(_configuration.GetValue<string>("Backend") + "api/Category");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<CategoryShare>>();
        }
    }

}
