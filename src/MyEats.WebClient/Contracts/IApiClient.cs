using MyEats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyEats.WebClient.Contracts
{
    public interface IApiClient
    {
        Task<IEnumerable<UserEntity>> GetAllCustomers();
        //Task<Api.Models.Customer> GetCustomerById(int id);
        //Task<bool> AddCustomer(Api.Entities.Customer customer);
    }
}
