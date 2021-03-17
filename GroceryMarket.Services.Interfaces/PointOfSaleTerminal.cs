using System;
using System.Collections.Generic;
using System.Linq;
using GroceryMarket.Domain.Core;
using GroceryMarket.Infrastructure.Data;
using GroceryMarket.Services.DTOs;
using GroceryMarket.Services.Exceptions;

namespace GroceryMarket.Services
{
    public class PointOfSaleTerminal : IPointOfSaleTerminal
    {
        private readonly ProductContext _context;
        private readonly IPriceCalculator _priceCalculator;
        private readonly IPriceSetter _priceSetter;
        private readonly Dictionary<Product, int> _basket;

        public PointOfSaleTerminal(ProductContext context, IPriceCalculator priceCalculator, IPriceSetter priceSetter)
        {
            _context = context ?? throw new ArgumentException(nameof(priceCalculator));
            _priceCalculator = priceCalculator ?? throw new ArgumentException(nameof(priceCalculator));
            _priceSetter = priceSetter ?? throw new ArgumentException(nameof(priceCalculator));
            _basket = new Dictionary<Product, int>();
        }

        public void ScanProduct(string productCode)
        {
            if (string.IsNullOrEmpty(productCode))
                throw new ArgumentException("Product code is empty", nameof(productCode));

            Product product = _context.Products.FirstOrDefault(p => p.Name == productCode);

            if (product == null)
            {
                throw new ProductDoesNotExist("Product with given name doesn't exist");
            }

            _context.Entry(product)
                .Reference(p => p.Discount).Load();

            _context.Entry(product)
                .Reference(p => p.Price).Load();

            if (!_basket.TryAdd(product, 1))
            {
                _basket[product]++;// increment product quantity
            }
        }
        public decimal GetTotalPrice()
        {
            return _priceCalculator.CalculateTotalPrice(_basket);
        }

        public void SetPricing(IEnumerable<ProductDto> products)
        {
            if (products == null || !products.Any())
                throw new ArgumentException("Product collection is empty", nameof(products));

            _priceSetter.SetProductsPricing(products, _context);
        }
    }
}
