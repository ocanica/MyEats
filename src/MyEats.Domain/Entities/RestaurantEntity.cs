using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyEats.Domain.Entities
{
    public class RestaurantEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RestaurantId { get; set; }

        [Required]
        [MaxLength(150)]
        [Column(TypeName = "varchar(150)")]
        public string Name { get; set; }

        [ForeignKey("PostcodeEntity")]
        public int PostcodeId { get; set; }
        public PostcodeEntity Postcode { get; set; }
    }
}
