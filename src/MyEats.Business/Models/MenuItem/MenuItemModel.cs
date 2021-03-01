using System;
using System.Collections.Generic;
using System.Text;

namespace MyEats.Business.Models.MenuItem
{
    public class MenuItemModel
    {
        public int MenuItemId { get; set; }
        public Guid RestaurantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
