using GroceryMarket.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroceryMarket.Infrastructure.Data.Populating
{
    public class VolumeDiscountPopulation : IEntityTypeConfiguration<VolumeDiscount>
    {
        public void Configure(EntityTypeBuilder<VolumeDiscount> builder)
        {
            builder.HasData(
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
                        VolumePrice = 5,
                        QuantityForDiscount = 6,
                        ProductId = 3
                    }
            );
        }
    }
}
