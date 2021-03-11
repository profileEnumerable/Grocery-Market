using GroceryMarket.Infrastructure.Data;
using GroceryMarket.Services;
using GroceryMarket.Services.Exceptions;
using System;
using System.Collections.Generic;
using GroceryMarket.Services.DTOs;

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

                var productsForUpdate = new List<ProductDto>()
                {
                    new ProductDto() {Name = "A", Price = new PriceDto {PricePerUnit = 3}},
                    new ProductDto() {Name = "F", Price = new PriceDto {PricePerUnit = 10}},
                    new ProductDto()
                    {
                        Name = "G",
                        Price = new PriceDto {PricePerUnit = 5},
                        Discount = new DiscountDto() {VolumePrice = 20, QuantityForDiscount = 5}
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

