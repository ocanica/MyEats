using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyEats.Business.Models;
using MyEats.Business.Repository;
using MyEats.Business.Services.Customer;
using MyEats.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyEats.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Customers controller")]
    public class CustomersController : Controller
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerService _service;

        public CustomersController(
            ILogger<CustomersController> logger,
            ICustomerService service
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
        [SwaggerResponse(200, "List of customer details", typeof(IEnumerable<CustomerEntity>))]
        [SwaggerResponse(404, description: "Unable to retrieve list of customer records")]
        public async Task<IActionResult> GetAllCustomers()
        {
            _logger.LogInformation($"Request received {nameof(CustomersController)} at {nameof(GetAllCustomers)} endpoint");

            var result = await _service.GetAllCustomers();

            return Ok(result);
        }

        [Authorize]
        [HttpGet("{customerId}")]
        [SwaggerResponse(200, "Retrieved customer", typeof(CustomerEntity))]
        [SwaggerResponse(400, description: "Invalid identifier")]
        [SwaggerResponse(404, description: "Unable to retrieve customer record")]
        public async Task<IActionResult> GetCustomerById(Guid customerId)
        {
            _logger.LogInformation($"Request received {nameof(CustomersController)} at {nameof(GetCustomerById)} endpoint");

            if (_service.GetCustomerById(customerId) == null)
                return NotFound("Customer identfier not found.");

            var result = await _service.GetCustomerById(customerId);

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
