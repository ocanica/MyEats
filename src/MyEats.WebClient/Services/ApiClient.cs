using MyEats.Domain.Entities;
using MyEats.WebClient.Contracts;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyEats.WebClient.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<UserEntity>> GetAllCustomers()
        {
            var response = await _httpClient.GetAsync($"api/customers");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            var customers = await response.Content.ReadAsStringAsync();

            var test = JsonSerializer.Deserialize<IEnumerable<UserEntity>>(customers);

            return test;
        }

        //public async Task<Api.Models.Customer> GetCustomerById(int id)
        //{
        //    var response = await _httpClient.GetAsync($"api/customers/{id}");

        //    if (response.StatusCode == HttpStatusCode.NotFound)
        //        return null;

        //    response.EnsureSuccessStatusCode();
        //    var customer = await response.Content.ReadAsStreamAsync();

        //    return await JsonSerializer.DeserializeAsync<Api.Models.Customer>(customer);
        //}

        //public async Task<bool> AddCustomer(Api.Entities.Customer customer)
        //{
        //    var response = await _httpClient.
        //        PostAsync($"api/customers", 
        //        new StringContent(
        //            JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json"
        //            )
        //        );

        //    if (response.StatusCode == HttpStatusCode.Conflict)
        //        return false;

        //    response.EnsureSuccessStatusCode();

        //    return true;
        //}
    }
}
