using AutoMapper;
using Microsoft.Extensions.Logging;
using MyEats.Business.Helper;
using MyEats.Business.Models.User;
using MyEats.Business.Repository;
using MyEats.Business.Services.Postcode;
using MyEats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyEats.Business.Services.User
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostcodeService _postcodeService;
        private readonly IMapper _mapper;

        public UserService(ILogger<UserService> logger, 
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IPostcodeService postcodeService)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _postcodeService = postcodeService;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            _logger.LogDebug($"{nameof(UserService)} init {nameof(GetAllUsers)}");
            
            var users = await _unitOfWork.Users.GetAllAsync();

            var result = _mapper.Map<IEnumerable<UserModel>>(users);

            _logger.LogDebug($"{nameof(UserService)} end {nameof(GetAllUsers)}");

            return result;
        }

        public async Task<UserModel> GetUserById(Guid id)
        {
            _logger.LogDebug($"{nameof(UserService)} init {nameof(GetUserById)}");

            var user = await _unitOfWork.Users.GetAsync(id);

            var result = _mapper.Map<UserModel>(user);

            _logger.LogDebug($"{nameof(UserService)} end {nameof(GetUserById)}");

            return result;
        }

        public bool UserExists(UserCreateModel user)
        {
            _logger.LogDebug($"{nameof(UserService)} init {nameof(UserExists)}");

            var exists = _unitOfWork.Users.Find(x => x.Email == user.Email).Any();

            _logger.LogDebug($"{nameof(UserService)} end {nameof(UserExists)}");

            return exists;
        }

        public bool UserExistsById(Guid userId)
        {
            _logger.LogDebug($"{nameof(UserService)} init {nameof(UserExists)}");

            var exists = _unitOfWork.Users.Find(x => x.UserId == userId).Any();

            _logger.LogDebug($"{nameof(UserService)} end {nameof(UserExists)}");

            return exists;
        }

        public async Task<UserModel> CreateUser(UserCreateModel user)
        {
            try
            {
                _logger.LogDebug($"{nameof(UserService)} init {nameof(CreateUser)}");
                
                var modelToCreate = new UserEntity()
                {
                    UserId = Guid.NewGuid(),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    PhoneNumber = user.PhoneNumber,
                    StreetAddress = user.StreetAddress,
                    Postcode = user.Postcode,
                    PostcodeId = _postcodeService.GetPostcodeId(user.Postcode),
                    City = user.City,
                    DateRegistered = DateTime.UtcNow
                };

                await _unitOfWork.Users.AddAsync(modelToCreate);
                await _unitOfWork.Save();

                var result = _mapper.Map<UserModel>(modelToCreate);

                _logger.LogDebug($"{nameof(UserService)} end {nameof(CreateUser)}");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating new User. Error {ex.InnerException}");
                throw new Exception(ex.Message);
            }
        }

        public async Task RemoveUserById(Guid userId)
        {
            try
            {
                _logger.LogDebug($"{nameof(UserService)} init {nameof(RemoveUserById)}");

                var user = await _unitOfWork.Users.GetAsync(userId);
                _unitOfWork.Users.Remove(user);
                await _unitOfWork.Save();

                _logger.LogDebug($"{nameof(UserService)} end {nameof(RemoveUserById)}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error removing User. Error {ex.InnerException}");
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserModel> UpdateUser(Guid userId, UserUpdateModel user)
        {
            try
            {
                _logger.LogDebug($"{nameof(UserService)} init {nameof(UpdateUser)}");

                var modelToUpdate = _unitOfWork.Users.Find(x => x.UserId == userId).FirstOrDefault();

                modelToUpdate.FirstName = user.FirstName ?? modelToUpdate.FirstName;
                modelToUpdate.LastName = user.LastName ?? modelToUpdate.LastName;
                modelToUpdate.Password = user.Password ?? modelToUpdate.Password;
                modelToUpdate.PhoneNumber = user.PhoneNumber ?? modelToUpdate.PhoneNumber;
                modelToUpdate.StreetAddress = user.StreetAddress ?? modelToUpdate.StreetAddress;
                modelToUpdate.Postcode = user.Postcode ?? modelToUpdate.Postcode;
                modelToUpdate.PostcodeId = _postcodeService.GetPostcodeId(modelToUpdate.Postcode);
                modelToUpdate.Town = _postcodeService.GetTown(modelToUpdate.Postcode);
                modelToUpdate.City = user.City ?? modelToUpdate.City;
                modelToUpdate.DateUpdated = DateTime.UtcNow;

                await _unitOfWork.Save();
                var result = _mapper.Map<UserModel>(modelToUpdate);

                _logger.LogDebug($"{nameof(UserService)} end {nameof(UpdateUser)}");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while updating User. Error {ex.InnerException}");
                throw new Exception(ex.Message);
            }
        }
    }
}
