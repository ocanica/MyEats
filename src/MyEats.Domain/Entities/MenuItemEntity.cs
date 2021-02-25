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

        [ForeignKey("RestaurantEntity")]
        public Guid RestaurantId { get; set; }
        public RestaurantEntity Restaurant { get; set; }

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string Description { get; set; }

        [ForeignKey("CategoryEntity")]
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "boolean")]
        public bool Active { get; set; }
    }
}
