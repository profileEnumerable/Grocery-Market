using GroceryMarket.Domain.Core;
using GroceryMarket.Infrastructure.Data;
using System.Collections.Generic;
using GroceryMarket.Services.DTOs;

namespace GroceryMarket.Services
{
    public interface IPriceSetter
    {
        void SetPricing(IEnumerable<ProductDto> products, ProductContext context);
    }
}