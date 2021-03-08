using GroceryMarket.Domain.Core;
using GroceryMarket.Infrastructure.Data.Populating;
using Microsoft.EntityFrameworkCore;

namespace GroceryMarket.Infrastructure.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Discount> Prices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("GroceryStore");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductPopulation());
            modelBuilder.ApplyConfiguration(new PricePopulation());
            modelBuilder.ApplyConfiguration(new DiscountPopulation());
        }
    }
}