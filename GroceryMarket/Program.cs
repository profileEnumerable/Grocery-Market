using System;
using System.Collections.Generic;
using GroceryMarket.Infrastructure.Business;
using GroceryMarket.Infrastructure.Business.Exceptions;
using GroceryMarket.Infrastructure.Data;

namespace GroceryMarket
{
    class Program
    {
        static void Main()
        {
            var products = new List<string>() { "A", "B", "C", "D" };

            using var productContext = new ProductContext();
            productContext.Database.EnsureCreated();

            var saleTerminal = new PointOfSaleTerminal(productContext);

            foreach (var product in products)
            {
                try
                {
                    saleTerminal.ScanProduct(product);
                }
                catch (ProductDoesNotExist e)
                {
                    Console.WriteLine(e);
                }
            }

            double? totalPrice = saleTerminal.CalculateTotalPrice();

            Console.WriteLine($"Total price {totalPrice}");
        }
    }
}

