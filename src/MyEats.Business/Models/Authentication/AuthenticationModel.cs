using System;
using System.Collections.Generic;
using System.Text;

namespace MyEats.Business.Models.Authentication
{
    public class AuthenticationModel
    {
        public Guid Id { get; set; }

        public string Token { get; set; }
    }
}
