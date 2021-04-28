using CustomerSite.Extentions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSite.SerVices
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public ProductApiClient(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }
        public async Task<IList<ProductShare>> GetProducts()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(_configuration.GetValue<string>("Backend") + "Product");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<ProductShare>>();
        }

        public async Task<ProductShare> GetProductById(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(_configuration.GetValue<string>("Backend") + "Product/" +id.ToString());
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ProductShare>();
        }

        public async Task<IList<ProductFromCategory>> GetProductByCategory(string categoryName)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(_configuration.GetValue<string>("Backend") + "Product/category=" + categoryName);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<ProductFromCategory>>();
        }

        public async  Task<bool> Rating(int productId, int values)
        {
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            var client = _httpClientFactory.CreateClient();
            client.UseBearerToken(accessToken);
            var rateRequest = new RateShare
            {
                ProductId = productId,
                value = values
            };  
            var json = JsonConvert.SerializeObject(rateRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PostAsync(_configuration.GetValue<string>("Backend") + "api/Rate", data);

            res.EnsureSuccessStatusCode();

            var result = await res.Content.ReadAsAsync<bool>();

            return result;
        }
    }
}
