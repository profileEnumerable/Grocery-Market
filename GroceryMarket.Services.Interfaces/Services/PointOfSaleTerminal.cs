using System.Collections.Generic;
using System.Linq;
using GroceryMarket.Domain.Core;
using GroceryMarket.Infrastructure.Data;
using GroceryMarket.Services.Exceptions;

namespace GroceryMarket.Services.Services
{
    public class PointOfSaleTerminal : IPointOfSaleTerminal
    {
        private readonly ProductContext _context;
        private readonly IPriceCalculator _priceCalculator;
        private readonly Dictionary<Product, int> _basket;

        public PointOfSaleTerminal(ProductContext context, IPriceCalculator priceCalculator)
        {
            _context = context;
            _priceCalculator = priceCalculator;
            _basket = new Dictionary<Product, int>();
        }

        public void ScanProduct(string productCode)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Code == productCode);

            if (product == null)
            {
                throw new ProductDoesNotExist("Product with given name doesn't exist");
            }

            _context.Entry(product)
                .Reference(p => p.VolumeDiscount).Load();

            if (!_basket.TryAdd(product, 1))
            {
                _basket[product]++;// increment product quantity
            }
        }
        public decimal GetTotalPrice()
        {
            return _priceCalculator.CalculateTotalPrice(_basket);
        }
    }
}
