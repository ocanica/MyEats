using System;
using System.Collections.Generic;
using System.Text;

namespace MyEats.Business.Models.InOrder
{
    public class InOrderModel
    {
        public int InOrderId { get; set; }

        public int OrderId { get; set; }

        public int MenuItemId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}