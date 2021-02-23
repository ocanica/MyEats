using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyEats.Domain.Entities
{
    public class RestaurantEntity
    {
#nullable enable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RestaurantId { get; set; }

        public Guid UserId { get; set; }

        public int PostcodeId { get; set; }
#nullable disable
    }
}
