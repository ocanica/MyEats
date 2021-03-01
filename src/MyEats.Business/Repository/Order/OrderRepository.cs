using MyEats.Domain;
using MyEats.Business.Models;
using Microsoft.Extensions.Logging;
using MyEats.Domain.Entities;

namespace MyEats.Business.Repository
{
    public class OrderRepository : RepositoryBase<OrderEntity>, IOrderRepository
    {
        public OrderRepository(MyEatsDataContext context)
            : base(context)
        {
        }
    }
}
