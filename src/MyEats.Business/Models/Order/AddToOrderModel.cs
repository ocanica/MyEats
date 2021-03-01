using System;
using System.Collections.Generic;
using System.Text;

namespace MyEats.Business.Models.Order
{
    public class AddToOrderModel
    {
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
    }
}
