using MyEats.Business.Models;
using MyEats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyEats.Business.Services.User
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllUsers();

        Task<UserModel> GetUserById(Guid id);
    }
}