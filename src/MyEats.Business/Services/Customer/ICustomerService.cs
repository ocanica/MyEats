using MyEats.Business.Models;
using MyEats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyEats.Business.Services.Customer
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerModel>> GetAllCustomers();

        Task<CustomerModel> GetCustomerById(Guid id);
    }
}