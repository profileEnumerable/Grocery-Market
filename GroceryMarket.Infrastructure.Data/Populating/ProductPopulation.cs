using GroceryMarket.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroceryMarket.Infrastructure.Data.Populating
{
    public class ProductPopulation : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                    new Product { Id = 1, Code = "A", PricePerUnit = 1.25M },
                    new Product { Id = 2, Code = "B", PricePerUnit = 4.25M },
                    new Product { Id = 3, Code = "C", PricePerUnit = 1 },
                    new Product { Id = 4, Code = "D", PricePerUnit = 0.75M }
                );
        }
    }
}
