using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyEats.Domain.Entities
{
    public class OrderEntity
    {
        [Key]
        public int OrderId { get; set; }

        public Guid UserId { get; set; }
        public UserEntity User { get; set; }

        public Guid RestaurantId { get; set; }
        public RestaurantEntity Restaurant { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal TotalPrice { get; set; }

        [Column(TypeName = "integer")]
        public int Items { get; set; }

        public DateTime DateOrdered { get; set; }

        public IEnumerable<InOrderEntity> InOrders { get; set; }

        
    }
}
