using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyEats.Domain.Entities
{
    public class CuisineEntity
    {
        [Key]
        public int CuisineId { get; set; }

        public string CuisineName { get; set; }
    }
}
