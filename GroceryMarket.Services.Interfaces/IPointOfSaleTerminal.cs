using System.Collections.Generic;
using GroceryMarket.Domain.Core;

namespace GroceryMarket.Services.Interfaces
{
    public interface IPointOfSaleTerminal
    {
        void SetPricing(IEnumerable<Product> products);
        void ScanProduct(string productName);
        double CalculateTotalPrice();
    }
}
