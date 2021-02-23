using AutoMapper;
using Microsoft.Extensions.Logging;
using MyEats.Business.Models;
using MyEats.Business.Repository;
using MyEats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEats.Business.Services.User
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(ILogger<UserService> logger, 
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            _logger.LogDebug($"{nameof(UserService)} end {nameof(GetAllUsers)}");
            
            var customers = await _unitOfWork.Users.GetAllAsync();

            var result = _mapper.Map<IEnumerable<UserModel>>(customers);

            return result;
        }

        public async Task<UserModel> GetUserById(Guid id)
        {
            _logger.LogDebug($"{nameof(UserService)} end {nameof(GetUserById)}");

            var customer = await _unitOfWork.Users.GetAsync(id);

            var result = _mapper.Map<UserModel>(customer);

            return result;
        }

    }
}
