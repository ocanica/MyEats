using System;
using System.Threading.Tasks;

namespace MyEats.Business.Repository.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepository Customers { get; }

        Task Save();
    }
}
