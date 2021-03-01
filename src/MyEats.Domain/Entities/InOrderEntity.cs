using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyEats.Domain.Entities
{
    public class InOrderEntity
    {
        [Key]
        public int InOrderId { get; set; }

        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }

        public int MenuItemId { get; set; }
        public MenuItemEntity MenuItem { get; set; }

        [Column(TypeName = "integer")]
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal Price { get; set; }
    }
}
