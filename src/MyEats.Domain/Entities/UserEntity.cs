using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEats.Domain.Entities
{
    public class UserEntity
    {
#nullable enable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

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
        [MaxLength(100)]
        [Column(TypeName = "varchar(150)")]
        public string Town { get; set; }

        [Required]
        [MaxLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string Postcode { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string City { get; set; }

        [Required]
        public DateTime DateRegistered { get; set; }

        public int? PostcodeId { get; set; }
#nullable disable
    }
}
