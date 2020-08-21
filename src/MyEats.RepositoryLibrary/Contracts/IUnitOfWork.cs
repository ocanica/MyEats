using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEats.RepositoryLibrary.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepository Customers { get; }

        Task Save();
    }
}
