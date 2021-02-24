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

        [ForeignKey("UserEntity")]
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }

        [ForeignKey("MenuItemEntity")]
        public int MenuItemId { get; set; }
        public IEnumerable<MenuItemEntity> MenuItem { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal TotalPrice { get; set; }

        [Required]
        public DateTime DateOrdered { get; set; }
    }
}
