using System;
using System.Threading.Tasks;

namespace MyEats.Business.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }

        Task Save();
    }
}
