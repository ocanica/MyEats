using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyEats.Business.Models;
using MyEats.Business.Repository;
using MyEats.Business.Services.User;
using MyEats.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyEats.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Users controller")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _service;

        public UsersController(
            ILogger<UsersController> logger,
            IUserService service
            )
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Get list of customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(200, "List of user details", typeof(IEnumerable<UserEntity>))]
        [SwaggerResponse(404, description: "Unable to retrieve list of user records")]
        public async Task<IActionResult> GetAllUsers()
        {
            _logger.LogInformation($"Request received {nameof(UsersController)} at {nameof(GetAllUsers)} endpoint");

            var result = await _service.GetAllUsers();

            return Ok(result);
        }

        [Authorize]
        [HttpGet("{userId}")]
        [SwaggerResponse(200, "Retrieved users", typeof(UserEntity))]
        [SwaggerResponse(400, description: "Invalid identifier")]
        [SwaggerResponse(404, description: "Unable to retrieve user record")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            _logger.LogInformation($"Request received {nameof(UsersController)} at {nameof(GetUserById)} endpoint");

            if (_service.GetUserById(userId) == null)
                return NotFound("Customer identfier not found.");

            var result = await _service.GetUserById(userId);

            return Ok(result);
        }

        /*[HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerModel customer)
        {
            if (customer == null)
                return BadRequest("Empty customer object");

            customer.CustomerId = Guid.NewGuid();
            await _unitOfWork.Customers.AddAsync(customer);
            var url = Url.Link("CustomerGet", new { customerId = customer.CustomerId });

            return Created(url, customer);
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> Update(Guid customerId, [FromBody] CustomerModel customer)
        {
            if (customer == null)
                return BadRequest("Empty customer object");

            var existingCustomer = await _unitOfWork.Customers.GetAsync(customerId);

            if (existingCustomer == null)
                return NotFound("Customer not found");

            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Email = customer.Email;
            existingCustomer.Password = customer.Password;
            existingCustomer.StreetAddress = customer.StreetAddress;
            existingCustomer.Town = customer.Town;
            existingCustomer.City = customer.City;
            existingCustomer.Postcode = customer.Postcode;

            await _unitOfWork.Save();

            return Ok(existingCustomer);
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> Delete(Guid customerId)
        {
            var existingCustomer = await _unitOfWork.Customers.GetAsync(customerId);

            if (existingCustomer == null)
                return NotFound("Customer not found");

            _unitOfWork.Customers.Remove(existingCustomer);
            await _unitOfWork.Save();

            return NoContent();
        }*/
    }
}
