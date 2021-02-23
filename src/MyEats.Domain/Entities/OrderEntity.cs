using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyEats.Domain.Entities
{
    public class OrderEntity
    {
#nullable enable
        [Key]
        public int OrderId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public int MenuItemId { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Price { get; set; }

        [Required]
        public DateTime DateOrdered { get; set; }
#nullable disable
    }
}
