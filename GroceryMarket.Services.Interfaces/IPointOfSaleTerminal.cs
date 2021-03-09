using System.Collections.Generic;
using GroceryMarket.Services.DTOs;

namespace GroceryMarket.Services
{
    public interface IPointOfSaleTerminal
    {
        void ScanProduct(string productName);
        decimal GetTotalPrice();
        void SetPricing(IEnumerable<ProductDto> products);
    }
}
