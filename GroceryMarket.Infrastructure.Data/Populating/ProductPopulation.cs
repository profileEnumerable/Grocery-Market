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
                    new Product { Id = 1, Name = "A" },
                    new Product { Id = 2, Name = "B" },
                    new Product { Id = 3, Name = "C" },
                    new Product { Id = 4, Name = "D" }
                );
        }
    }
}
