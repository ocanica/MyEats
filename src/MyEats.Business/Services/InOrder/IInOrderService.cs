using MyEats.Business.Models.InOrder;
using MyEats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEats.Business.Services.InOrder
{
    public interface IInOrderService
    {
        Task<InOrderEntity> GetInOrderByOrderAndMenuItemsIds(int orderId, int menuItemId);
        Task UpdateInOrderPrices();
        IEnumerable<InOrderEntity> GetInOrdersByOrderId(int orderId);
        bool InOrderExists(int inOrderId);
    }
}
