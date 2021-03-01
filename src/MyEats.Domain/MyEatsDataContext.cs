using Microsoft.EntityFrameworkCore;
using MyEats.Domain.Entities;

namespace MyEats.Domain
{
    public class MyEatsDataContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RestaurantEntity> Restaurants { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<PostcodeEntity> Postcodes { get; set; }
        public DbSet<MenuItemEntity> MenuItems { get; set; }
        public DbSet<InOrderEntity> InOrders { get; set; }
        public DbSet<CuisineEntity> Cuisines { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<DeliveryArea> DeliveryAreas { get; set; }
        public DbSet<RestaurantCuisine> RestaurantCuisines { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }

        public MyEatsDataContext(DbContextOptions<MyEatsDataContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliveryArea>()
                .HasKey(c => new { c.PostcodeID, c.RestaurantId });

            modelBuilder.Entity<RestaurantCuisine>()
                .HasKey(c => new { c.RestaurantId, c.CuisineId });

            modelBuilder.Entity<MenuCategory>()
                .HasKey(c => new { c.CategoryId, c.MenuItemId });
        }
    }
}
