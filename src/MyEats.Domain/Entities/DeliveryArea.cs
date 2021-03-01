using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyEats.Domain.Entities
{
    public class DeliveryArea
    {
        public int PostcodeID { get; set; }
        public PostcodeEntity Postcode { get; set; }
        public Guid RestaurantId { get; set; }
        public RestaurantEntity Restaurant { get; set; }
    }
}
