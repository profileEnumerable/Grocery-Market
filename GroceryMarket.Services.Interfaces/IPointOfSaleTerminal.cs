using System.Collections.Generic;
using GroceryMarket.Domain.Core;

namespace GroceryMarket.Services
{
    public interface IPointOfSaleTerminal
    {
        void ScanProduct(string productName);
        decimal GetTotalPrice();
        void SetPricing(IEnumerable<Product> products);
    }
}
