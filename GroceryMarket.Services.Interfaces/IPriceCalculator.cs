using System.Collections.Generic;
using GroceryMarket.Domain.Core;

namespace GroceryMarket.Services
{
    public interface IPriceCalculator
    {
        decimal CalculateTotalPrice(Dictionary<Product, int> basket);
    }
}
