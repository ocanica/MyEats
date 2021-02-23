using System;
using System.Threading.Tasks;

namespace MyEats.Business.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        Task Save();
    }
}
