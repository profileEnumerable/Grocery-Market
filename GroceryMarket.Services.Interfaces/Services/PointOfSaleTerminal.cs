﻿using System.Collections.Generic;
using System.Linq;
using GroceryMarket.Domain.Core;
using GroceryMarket.Infrastructure.Data;
using GroceryMarket.Services.Exceptions;

namespace GroceryMarket.Services.Services
{
    public class PointOfSaleTerminal : IPointOfSaleTerminal
    {
        private readonly ProductContext _context;
        private readonly Dictionary<Product, int> _basket;

        private decimal _totalPrice;

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
                .Reference(p => p.VolumeDiscount).Load();

            if (!_basket.TryAdd(product, 1))
            {
                _basket[product]++;// increment product quantity
            }
        }
        public decimal GetTotalPrice()
        {
            foreach (var productQuantityPair in _basket)
            {
                decimal singleProductPrice = 0;
                int unitsWithoutDiscount = productQuantityPair.Value;

                VolumeDiscount volumeDiscount = productQuantityPair.Key?.VolumeDiscount;

                if (volumeDiscount?.QuantityForDiscount <= productQuantityPair.Value)
                {
                    singleProductPrice = volumeDiscount.VolumePrice;
                    unitsWithoutDiscount -= volumeDiscount.QuantityForDiscount;
                }

                singleProductPrice += unitsWithoutDiscount * productQuantityPair.Key.PricePerUnit;

                _totalPrice += singleProductPrice;
            }
            return _totalPrice;
        }
    }
}