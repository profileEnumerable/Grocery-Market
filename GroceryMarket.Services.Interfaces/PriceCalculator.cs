using System.Collections.Generic;
using GroceryMarket.Domain.Core;

namespace GroceryMarket.Services
{
    public class PriceCalculator : IPriceCalculator
    {
        private decimal _totalPrice;

        public decimal TotalPrice => _totalPrice;

        public decimal CalculateTotalPrice(Dictionary<Product, int> basket)
        {
            foreach (var productQuantityPair in basket)
            {
                decimal singleProductPrice = 0;
                int unitsWithoutDiscount = productQuantityPair.Value;

                VolumeDiscount volumeDiscount = productQuantityPair.Key?.VolumeDiscount;

                if (volumeDiscount?.QuantityForDiscount <= productQuantityPair.Value)
                {
                    singleProductPrice = volumeDiscount.VolumePrice;
                    unitsWithoutDiscount -= volumeDiscount.QuantityForDiscount;
                }

                singleProductPrice += unitsWithoutDiscount * productQuantityPair.Key.PricePerUnit;

                _totalPrice += singleProductPrice;
            }

            return _totalPrice;
        }
    }
}
