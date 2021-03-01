using MyEats.Business.Repository.InOrder;
using System;
using System.Threading.Tasks;

namespace MyEats.Business.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        IPostcodeRepository Postcodes { get; }

        IOrderRepository Orders { get; }

        IMenuItemRepository MenuItems { get; }

        IInOrderRepository InOrders { get; }

        Task Save();
    }
}
