using MyEats.Business.Models.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyEats.Business.Services.User
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllUsers();

        Task<UserModel> GetUserById(Guid id);

        bool UserExists(UserCreateModel user);

        bool UserExistsById(Guid userId);

        Task<UserModel> CreateUser(UserCreateModel user);
        Task RemoveUserById(Guid userId);
        Task<UserModel> UpdateUser(Guid userId, UserUpdateModel user);
    }
}