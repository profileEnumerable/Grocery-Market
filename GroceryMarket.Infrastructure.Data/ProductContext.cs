using GroceryMarket.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace GroceryMarket.Infrastructure.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<VolumeDiscount> Prices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("GroceryStore");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product { Id = 1, Code = "A", PricePerUnit = 1.25 },
                    new Product { Id = 2, Code = "B", PricePerUnit = 4.25 },
                    new Product { Id = 3, Code = "C", PricePerUnit = 1 },
                    new Product { Id = 4, Code = "D", PricePerUnit = 0.75 }
                    );

            modelBuilder.Entity<VolumeDiscount>()
                .HasData(
                    new VolumeDiscount
                    {
                        Id = 1,
                        VolumePrice = 3,
                        QuantityForDiscount = 3,
                        ProductId = 1
                    },
                    new VolumeDiscount
                    {
                        Id = 2,
                        VolumePrice = null,
                        QuantityForDiscount = null,
                        ProductId = 2
                    },
                    new VolumeDiscount
                    {
                        Id = 3,
                        VolumePrice = 5,
                        QuantityForDiscount = 6,
                        ProductId = 3
                    },
                    new VolumeDiscount
                    {
                        Id = 4,
                        VolumePrice = null,
                        QuantityForDiscount = null,
                        ProductId = 4
                    }
                );
        }
    }
}