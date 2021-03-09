using GroceryMarket.Domain.Core;
using GroceryMarket.Infrastructure.Data;
using GroceryMarket.Services;
using GroceryMarket.Services.Exceptions;
using System;
using System.Collections.Generic;

namespace GroceryMarket
{
    class Program
    {
        static void Main()
        {
            var productsForScan = new List<string>() { "A", "B", "C", "D" };

            using (var productContext = new ProductContext())
            {
                productContext.Database.EnsureCreated();

                var saleTerminal = new PointOfSaleTerminal(productContext, new PriceCalculator(), new PriceSetter());

                var productsForUpdate = new List<Product>()
                {
                    new Product() {Name = "A", Price = new Price {PricePerUnit = 3 } },
                    new Product() {Name = "F", Price = new Price { PricePerUnit = 10 } },
                    new Product()
                    {
                        Name = "G",
                        Price = new Price { PricePerUnit = 5 },
                        Discount = new Discount() {VolumePrice = 20, QuantityForDiscount = 5}
                    }
                };

                saleTerminal.SetPricing(productsForUpdate);

                foreach (var product in productsForScan)
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

