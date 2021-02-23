using MyEats.Domain;
using MyEats.Business.Models;
using Microsoft.Extensions.Logging;
using MyEats.Domain.Entities;

namespace MyEats.Business.Repository
{
    public class CustomerRepository : RepositoryBase<CustomerEntity>, ICustomerRepository
    {
        public CustomerRepository(DataContext context)
            : base(context)
        {
        }
    }
}
