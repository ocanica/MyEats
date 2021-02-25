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
        [SwaggerResponse(400, description: "Something went wrong while retrieving the user")]
        [SwaggerResponse(404, description: "Unable to retrieve user record")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            _logger.LogInformation($"Request received {nameof(UsersController)} at {nameof(GetUserById)} endpoint");

            if (!_service.UserExistsById(userId))
                return NotFound("User identfier not found.");

            var result = await _service.GetUserById(userId);

            return Ok(result);
        }

        [HttpPost]
        [SwaggerResponse(201, "Created user", typeof(UserCreateModel))]
        [SwaggerResponse(400, "Something went wrong while creating the user")]
        public async Task<IActionResult> CreateNewUser(UserCreateModel user)
        {
            _logger.LogInformation($"Request received {nameof(UsersController)} at {nameof(CreateNewUser)} endpoint");

            if (_service.UserExists(user))
                return BadRequest("Email already exists");

            var model = await _service.CreateUser(user);

            if (model == null)
                return BadRequest("Something went wrong while creating user");

            _logger.LogInformation($"User {model.UserId} created at {DateTime.UtcNow.ToLongTimeString()}");

            return CreatedAtAction(nameof(CreateNewUser), model.UserId);
        }

        [Authorize]
        [HttpPut("{userId}")]
        [SwaggerResponse(200, "Updated user", typeof(UserUpdateModel))]
        [SwaggerResponse(400, description: "Something went wrong while updating the user")]
        [SwaggerResponse(404, description: "Unable to retrieve user record")]
        public async Task<IActionResult> UpdateUser(Guid userId, UserUpdateModel user)
        {
            _logger.LogInformation($"Request received {nameof(UsersController)} at {nameof(UpdateUser)} endpoint");

            if (!_service.UserExistsById(userId))
                return NotFound("User identfier not found.");

            var model = await _service.UpdateUser(userId, user);

            if (model == null)
                return BadRequest("Something went wrong while creating user");

            _logger.LogInformation($"User {model.UserId} updated at {DateTime.UtcNow.ToLongTimeString()}");

            return Ok(model);
        }

        [Authorize]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            _logger.LogInformation($"Request received {nameof(UsersController)} at {nameof(DeleteUser)} endpoint");

            if (!_service.UserExistsById(userId))
                return NotFound("Customer identfier not found.");

            await _service.RemoveUserById(userId);

            _logger.LogInformation($"User {userId} deleted at {DateTime.UtcNow.ToLongTimeString()}");
            return NoContent();
        }
    }
}
