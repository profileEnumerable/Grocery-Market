using GroceryMarket.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroceryMarket.Infrastructure.Data.Populating
{
    class PricePopulation : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.HasData(
                new Price { Id = 1, PricePerUnit = 1.25M, ProductId = 1 },
                new Price { Id = 2, PricePerUnit = 4.25M, ProductId = 2 },
                new Price { Id = 3, PricePerUnit = 1, ProductId = 3 },
                new Price { Id = 4, PricePerUnit = 0.75M, ProductId = 4 }
                );
        }
    }
}
