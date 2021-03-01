using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyEats.Domain.Entities
{
    public class MenuItemEntity
    {
        [Key]
        public int MenuItemId { get; set; }

        public Guid RestaurantId { get; set; }
        public RestaurantEntity Restaurant { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        [Column(TypeName = "varchar(150)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "boolean")]
        public bool Active { get; set; }
    }
}
