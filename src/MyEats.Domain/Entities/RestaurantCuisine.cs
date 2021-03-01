using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyEats.Domain.Entities
{
    public class RestaurantCuisine
    {
        public Guid RestaurantId { get; set; }
        public RestaurantEntity Restaurant { get; set; }

        public int CuisineId { get; set; }
        public CuisineEntity Cuisine { get; set; }
    }
}
