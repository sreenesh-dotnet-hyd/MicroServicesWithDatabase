using Azure;
using OrdersService.Models;

namespace OrdersService
{
    public class ProductAPIClient
    {
        private readonly HttpClient _httpClient;
        public ProductAPIClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> GetProductByIDAsync(int? productId)
        {
            var res = await _httpClient.GetAsync($"/api/Products/{productId}");

            if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                return false;
            res.EnsureSuccessStatusCode();
            return true;
        }

    }
}
