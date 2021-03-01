using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyEats.Domain.Entities
{
    public class MenuCategory
    {
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }

        public int MenuItemId { get; set; }
        public MenuItemEntity MenuItem { get; set; }
    }
}
