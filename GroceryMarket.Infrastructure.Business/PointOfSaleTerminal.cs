using System;
using System.Collections.Generic;
using System.Linq;
using GroceryMarket.Domain.Core;
using GroceryMarket.Infrastructure.Data;
using GroceryMarket.Services.Interfaces;

namespace GroceryMarket.Infrastructure.Business
{
    public class PointOfSaleTerminal : IPointOfSaleTerminal, IDisposable
    {
        private readonly ProductContext _context;
        public PointOfSaleTerminal()
        {
            _context = new ProductContext();
        }

        public void SetPricing(IEnumerable<Product> products)
        {
            _context.AddRange(products);
            _context.SaveChanges();
        }

        public void ScanProduct(string productName)
        {
        }

        public double CalculateTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
