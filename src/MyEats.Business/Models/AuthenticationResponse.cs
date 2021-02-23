using MyEats.Domain.Entities;
using System;

namespace MyEats.Business.Models
{
    public class AuthenticationResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public AuthenticationResponse(CustomerEntity customer, string token)
        {
            Id = customer.CustomerId;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
            Token = token;
        }
    }
}
