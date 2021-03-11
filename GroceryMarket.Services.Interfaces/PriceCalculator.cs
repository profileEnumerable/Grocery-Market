using System.Collections.Generic;
using GroceryMarket.Domain.Core;

namespace GroceryMarket.Services
{
    public class PriceCalculator : IPriceCalculator
    {
        public decimal CalculateTotalPrice(Dictionary<Product, int> basket)
        {
            decimal totalPrice = 0;

            foreach (var productQuantityPair in basket)
            {
                decimal singleProductPrice = 0;
                int unitsWithoutDiscount = productQuantityPair.Value;

                Discount volumeDiscount = productQuantityPair.Key?.Discount;

                if (volumeDiscount?.QuantityForDiscount <= productQuantityPair.Value)
                {
                    singleProductPrice = volumeDiscount.VolumePrice;
                    unitsWithoutDiscount -= volumeDiscount.QuantityForDiscount;
                }

                singleProductPrice += unitsWithoutDiscount * productQuantityPair.Key.Price.PricePerUnit;

                totalPrice += singleProductPrice;
            }

            return totalPrice;
        }
    }
}
