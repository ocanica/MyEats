using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyEats.Business.Models;
using MyEats.Business.Repository.Contracts;
using MyEats.Business.Services.Contracts;
using MyEats.Domain.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MyEats.Business.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationService(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _unitOfWork.Customers.Find(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
            
            if (user == null) return null;

            var token = generateJSONWebToken(user);

            return new AuthenticateResponse(user, token);
        }

        private string generateJSONWebToken(Customer customer)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, customer.CustomerId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
