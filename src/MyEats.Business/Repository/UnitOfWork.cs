using MyEats.Domain;
using MyEats.Business.Repository.Contracts;
using System;
using System.Threading.Tasks;

namespace MyEats.Business.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public ICustomersRepository Customers { get; private set; }

        public UnitOfWork(DataContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
            Customers = new CustomersRepository(context);
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
