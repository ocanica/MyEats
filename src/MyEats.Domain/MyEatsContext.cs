using Microsoft.EntityFrameworkCore;
using MyEats.Domain.Entities;

namespace MyEats.Domain
{
    public class DataContext : DbContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<PostcodeEntity> Postcodes { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
    }
}
