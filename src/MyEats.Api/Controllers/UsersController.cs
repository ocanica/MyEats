using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyEats.Business.Models.User;
using MyEats.Business.Services.User;
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
        [SwaggerResponse(200, "List of user details", typeof(IEnumerable<UserModel>))]
        [SwaggerResponse(404, description: "Unable to retrieve list of user records")]
        public async Task<IActionResult> GetAllUsers()
        {
            _logger.LogInformation($"Request received {nameof(UsersController)} at {nameof(GetAllUsers)} endpoint");

            var result = await _service.GetAllUsers();

            return Ok(result);
        }

        [Authorize]
        [HttpGet("{userId}")]
        [SwaggerResponse(200, "Retrieved users", typeof(UserModel))]
        [SwaggerResponse(400, description: "Invalid identifier")]
        [SwaggerResponse(404, description: "Unable to retrieve user record")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            _logger.LogInformation($"Request received {nameof(UsersController)} at {nameof(GetUserById)} endpoint");

            var userExists = _service.UserExistsById(userId);

            if (!userExists)
                return NotFound("Customer identfier not found.");

            var result = await _service.GetUserById(userId);

            return Ok(result);
        }

        [HttpPost]
        [SwaggerResponse(201, "Created user", typeof(UserCreateModel))]
        [SwaggerResponse(400, "Something went wrong creating while the user")]
        public async Task<IActionResult> CreateNewUser(UserCreateModel user)
        {
            _logger.LogInformation($"Request received {nameof(UsersController)} at {nameof(CreateNewUser)} endpoint");

            var userExists = _service.UserExists(user);

            if (userExists)
                return BadRequest("Email already exists");

            var model = await _service.CreateUser(user);

            return CreatedAtAction(nameof(CreateNewUser), model.UserId);
        }

        /*[HttpPut("{customerId}")]
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
        }*/

        [Authorize]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(Guid userId)
        {
            _logger.LogInformation($"Request received {nameof(UsersController)} at {nameof(Delete)} endpoint");

            var userExists = _service.UserExistsById(userId);

            if (!userExists)
                return NotFound("Customer identfier not found.");

            await _service.RemoveUserById(userId);

            return NoContent();
        }
    }
}
