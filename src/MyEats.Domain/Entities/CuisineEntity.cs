using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyEats.Domain.Entities
{
    public class CuisineEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CuisineId { get; set; }

        public string Name { get; set; }

        public IEnumerable<RestaurantEntity> Restaurants { get; set; }
    }
}
