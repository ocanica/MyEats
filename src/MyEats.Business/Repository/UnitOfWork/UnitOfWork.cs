using MyEats.Business.Repository.InOrder;
using MyEats.Domain;
using System;
using System.Threading.Tasks;

namespace MyEats.Business.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyEatsDataContext _context;
        public IUserRepository Users { get; private set; }
        public IPostcodeRepository Postcodes { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IMenuItemRepository MenuItems { get; private set; }
        public IInOrderRepository InOrders { get; private set; }

        public UnitOfWork(MyEatsDataContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));

            Users = new UserRepository(context);
            Postcodes = new PostcodeRepository(context);
            Orders = new OrderRepository(context);
            MenuItems = new MenuItemRepository(context);
            InOrders = new InOrderRepository(context);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
