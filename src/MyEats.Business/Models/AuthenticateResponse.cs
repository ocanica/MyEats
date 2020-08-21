using MyEats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEats.Business.Models
{
    public class AuthenticateResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(Customer customer, string token)
        {
            Id = customer.CustomerId;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
            Token = token;
        }
    }
}
