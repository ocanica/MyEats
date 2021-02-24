using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyEats.Domain.Entities
{
    public class PostcodeEntity
    {
        [Key]
        public int PostcodeId { get; set; }

        [Required]
        [MaxLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string PostcodePrefix { get; set; }

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "varchar(100)")]
        public string Town { get; set; }
    }
}
