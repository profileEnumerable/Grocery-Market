using System.Collections.Generic;
using System.Linq;
using GroceryMarket.Domain.Core;
using GroceryMarket.Infrastructure.Business.Exceptions;
using GroceryMarket.Infrastructure.Data;
using GroceryMarket.Services.Interfaces;

namespace GroceryMarket.Infrastructure.Business
{
    public class PointOfSaleTerminal : IPointOfSaleTerminal
    {
        private readonly ProductContext _context;
        private readonly Dictionary<Product, int> _basket;

        private double? _totalPrice = 0;

        public PointOfSaleTerminal(ProductContext context)
        {
            _context = context;
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
                .Reference(p => p.Price).Load();

            if (!_basket.TryGetValue(product, out int productQuantity))
            {
                _basket.Add(product, 1);
            }

            _basket[product] = ++productQuantity;
        }
        public double? CalculateTotalPrice()
        {
            foreach (var productQuantityPair in _basket)
            {
                double? singleProductPrice = 0;
                int? unitsWithoutDiscount = productQuantityPair.Value;

                Price price = productQuantityPair.Key.Price;

                if (price?.VolumeDiscountUnit <= productQuantityPair.Value)
                {
                    singleProductPrice = price.VolumePrice;
                    unitsWithoutDiscount -= price.VolumeDiscountUnit;
                }

                singleProductPrice += unitsWithoutDiscount * price.PricePerUnit;

                _totalPrice += singleProductPrice;
            }
            return _totalPrice;
        }
    }
}
