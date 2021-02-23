using Microsoft.EntityFrameworkCore;
using MyEats.Domain.Entities;

namespace MyEats.Domain
{
    public class DataContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RestaurantEntity> Restaurants { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<PostcodeEntity> Postcodes { get; set; }
        public DbSet<MenuItemEntity> MenuItems { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
    }
}
