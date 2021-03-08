using System.Collections.Generic;
using System.Linq;
using GroceryMarket.Domain.Core;
using GroceryMarket.Infrastructure.Data;
using GroceryMarket.Services.Exceptions;

namespace GroceryMarket.Services
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

        public void SetPricing(IEnumerable<Product> products)
        {
            foreach (Product product in products)
            {
                Product matchedProduct = _context.Products.FirstOrDefault(p => p.Name == product.Name);

                if (matchedProduct != null)
                {
                    _context.Entry(matchedProduct)
                        .Reference(p => p.Discount).Load();

                    _context.Entry(matchedProduct)
                        .Reference(p => p.Price).Load();

                    matchedProduct.Price.PricePerUnit = product.Price.PricePerUnit;

                    if (product.Discount != null)
                    {
                        matchedProduct.Discount.VolumePrice = product.Discount.VolumePrice;
                        matchedProduct.Discount.QuantityForDiscount = product.Discount.QuantityForDiscount;
                    }
                }
                else
                {
                    _context.Add(product);
                }
            }
            _context.SaveChanges();
        }
    }
}
