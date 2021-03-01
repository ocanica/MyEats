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
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(150)]
        [Column(TypeName = "varchar(150)")]
        public string StreetAddress { get; set; }

        [Required]
        [MaxLength(150)]
        [Column(TypeName = "varchar(150)")]
        public string Town { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string City { get; set; }

        [Required]
        [MaxLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string Postcode { get; set; }

        [ForeignKey("PostcodeEntity")]
        public int PostcodeId { get; set; }
        public PostcodeEntity PostCode { get; set; }

        [Required]
        public DateTime DateRegistered { get; set; }

        public DateTime? DateUpdated { get; set; }

        public IEnumerable<OrderEntity> Orders { get; set; }
    }
}
