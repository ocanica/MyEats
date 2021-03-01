using MyEats.Business.Models.Order;
using MyEats.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyEats.Business.Services.Order
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderModel>> GetAllOrders();
        Task<OrderEntity> GetOrderById(int orderId);
        bool OrderExists(int orderId);

        Task AddItemToOrder(int orderId, int menuItemId, int quantity);
    }
}
