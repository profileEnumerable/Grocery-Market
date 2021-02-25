using System.Collections.Generic;
using GroceryMarket.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace GroceryMarket.Infrastructure.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("GroceryStore");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Price>()
                .HasData(new List<Price>()
                {
                    new Price() {Id = 1, PricePerUnit = 1.25, VolumePrice = 3, VolumeDiscountUnit = 3},
                    new Price() {Id = 2, PricePerUnit = 4.25, VolumePrice = null, VolumeDiscountUnit = null},
                    new Price() {Id = 3, PricePerUnit = 1, VolumePrice = 5, VolumeDiscountUnit = 6},
                    new Price() {Id = 4, PricePerUnit = 0.75, VolumePrice = null, VolumeDiscountUnit = null}
                });

            modelBuilder.Entity<Product>()
                .HasData(new List<Product>()
                {
                    new Product() {Id = 1, Code = "A", ProductPriceId = 1},
                    new Product() {Id = 2, Code = "B", ProductPriceId = 2},
                    new Product() {Id = 3, Code = "C", ProductPriceId = 3},
                    new Product() {Id = 4, Code = "D", ProductPriceId = 4}
                });
        }
    }
}