using System;
using System.Collections.Generic;
using GroceryMarket.Domain.Core;
using GroceryMarket.Infrastructure.Business;

namespace GroceryMarket
{
    class Program
    {
        static void Main()
        {
            var products = new List<string>() { "A", "B", "C", "D", "A", "B", "A" };

            using (var saleTerminal = new PointOfSaleTerminal())
            {
                saleTerminal.SetPricing(new List<Product>());

                foreach (string product in products)
                {
                    saleTerminal.ScanProduct(product);
                }

                double totalPrice = saleTerminal.CalculateTotalPrice();

                Console.WriteLine($"Total price {totalPrice}");
            }
        }
    }
}
