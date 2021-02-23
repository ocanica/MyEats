using AutoMapper;
using Microsoft.Extensions.Logging;
using MyEats.Business.Models;
using MyEats.Business.Repository;
using MyEats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEats.Business.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(ILogger<CustomerService> logger, 
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CustomerModel>> GetAllCustomers()
        {
            _logger.LogDebug($"{nameof(CustomerService)} end {nameof(GetAllCustomers)}");
            
            var customers = await _unitOfWork.Customers.GetAllAsync();

            var result = _mapper.Map<IEnumerable<CustomerModel>>(customers);

            return result;
        }

        public async Task<CustomerModel> GetCustomerById(Guid id)
        {
            _logger.LogDebug($"{nameof(CustomerService)} end {nameof(GetCustomerById)}");

            var customer = await _unitOfWork.Customers.GetAsync(id);

            var result = _mapper.Map<CustomerModel>(customer);

            return result;
        }

    }
}
