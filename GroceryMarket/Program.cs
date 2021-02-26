using System;
using System.Collections.Generic;
using System.Threading.Channels;
using GroceryMarket.Infrastructure.Business;
using GroceryMarket.Infrastructure.Business.Exceptions;

namespace GroceryMarket
{
    class Program
    {
        static void Main()
        {
            var products = new List<string>() { "A", "B", "C", "D" };

            using var saleTerminal = new PointOfSaleTerminal();

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

