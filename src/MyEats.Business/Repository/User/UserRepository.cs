using MyEats.Domain;
using MyEats.Business.Models;
using Microsoft.Extensions.Logging;
using MyEats.Domain.Entities;

namespace MyEats.Business.Repository
{
    public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        public UserRepository(MyEatsDataContext context)
            : base(context)
        {
        }
    }
}
