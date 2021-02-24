using System;
using System.Collections.Generic;
using System.Text;

namespace MyEats.Business.Models.User
{
    public class UserModel
    {
        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string Postcode { get; set; }
    }
}
