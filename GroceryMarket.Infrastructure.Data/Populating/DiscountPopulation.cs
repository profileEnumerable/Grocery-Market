using GroceryMarket.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroceryMarket.Infrastructure.Data.Populating
{
    public class DiscountPopulation : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasData(
                    new Discount
                    {
                        Id = 1,
                        VolumePrice = 3,
                        QuantityForDiscount = 3,
                        ProductId = 1
                    },
                    new Discount
                    {
                        Id = 2,
                        VolumePrice = 5,
                        QuantityForDiscount = 6,
                        ProductId = 3
                    }
            );
        }
    }
}
