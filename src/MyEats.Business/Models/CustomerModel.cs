﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyEats.Business.Models
{
    public class CustomerModel
    {
        public Guid CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string StreetAddress { get; set; }

        public string Town { get; set; }

        public string City { get; set; }

        public string Postcode { get; set; }
    }
}
