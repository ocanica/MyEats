using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEats.Business.Repository.Contracts;
using MyEats.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace MyEats.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("User controller")]
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _unitOfWork.Customers.GetAllAsync();

            return Ok(customers);
        }

        [Authorize]
        [HttpGet("{customerId}", Name = "CustomerGet")]
        public async Task<IActionResult> GetAll(Guid customerId)
        {
            var customer = await _unitOfWork.Customers.GetAsync(customerId);

            if (customer == null)
                return NotFound("Customer was not found");

            customer.Password = null;

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest("Empty customer object");

            customer.CustomerId = Guid.NewGuid();
            await _unitOfWork.Customers.AddAsync(customer);
            var url = Url.Link("CustomerGet", new { customerId = customer.CustomerId });

            return Created(url, customer);
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> Update(Guid customerId, [FromBody]Customer customer)
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
        }
    }
}
