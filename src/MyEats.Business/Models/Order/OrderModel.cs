using MyEats.Business.Models.InOrder;
using System;
using System.Collections.Generic;

namespace MyEats.Business.Models.Order
{
    public class OrderModel
    {
        public int OrderId { get; set; }

        public Guid UserId { get; set; }

        public Guid RestaurantId { get; set; }

        public decimal TotalPrice { get; set; }

        public int Items { get; set; }

        public DateTime DateOrdered { get; set; }

        public IEnumerable<InOrderModel> InOrders { get; set; }
    }
}