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

        [ForeignKey("OrderEntity")]
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }

        [ForeignKey("MenuItemEntity")]
        public int MenuItemId { get; set; }
        public MenuItemEntity MenuItem { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Price { get; set; }
    }
}
