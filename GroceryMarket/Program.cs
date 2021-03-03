using System;
using System.Collections.Generic;
using GroceryMarket.Infrastructure.Data;
using GroceryMarket.Services;
using GroceryMarket.Services.Exceptions;
using GroceryMarket.Services.Services;

namespace GroceryMarket
{
    class Program
    {
        static void Main()
        {
            var products = new List<string>() { "A", "B", "C", "D" };

            using (var productContext = new ProductContext())
            {
                productContext.Database.EnsureCreated();

                var saleTerminal = new PointOfSaleTerminal(productContext, new PriceCalculator());

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

                decimal totalPrice = saleTerminal.GetTotalPrice();

                Console.WriteLine($"Total price {totalPrice}");
            }
        }
    }
}

