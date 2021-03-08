using GroceryMarket.Domain.Core;
using GroceryMarket.Infrastructure.Data;
using System.Collections.Generic;

namespace GroceryMarket.Services
{
    public interface IPriceSetter
    {
        void SetPricing(IEnumerable<Product> products, ProductContext context);
    }
}