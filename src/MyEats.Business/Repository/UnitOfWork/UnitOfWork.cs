using MyEats.Domain;
using System;
using System.Threading.Tasks;

namespace MyEats.Business.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyEatsDataContext _context;
        public IUserRepository Users { get; private set; }

        public UnitOfWork(MyEatsDataContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));

            Users = new UserRepository(context);
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
