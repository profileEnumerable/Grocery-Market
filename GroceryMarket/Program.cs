using System;
using System.Collections.Generic;
using GroceryMarket.Domain.Core;
using GroceryMarket.Infrastructure.Data;
using GroceryMarket.Services;
using GroceryMarket.Services.Exceptions;

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

                var saleTerminal = new PointOfSaleTerminal(productContext, new PriceCalculator());

                var productsForUpdate = new List<Product>()
                {
                    new Product() {Code = "A", PricePerUnit = 3},
                    new Product() {Code = "F", PricePerUnit = 10},
                    new Product()
                    {
                        Code = "G",
                        PricePerUnit = 5,
                        VolumeDiscount = new VolumeDiscount() {VolumePrice = 20, QuantityForDiscount = 5}
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

