using System;
using System.Collections.Generic;
using GroceryMarket.Services;
using GroceryMarket.Services.DTOs;
using GroceryMarket.Services.Exceptions;
using GroceryMarket.UnitTests.Fixtures;
using Xunit;

namespace GroceryMarket.UnitTests
{
    public class PointOfSaleTerminalShould : IClassFixture<EfContextFixture>
    {
        private readonly PointOfSaleTerminal _terminal;

        public PointOfSaleTerminalShould(EfContextFixture fixture)
        {
            _terminal = new PointOfSaleTerminal(fixture.Context, new PriceCalculator(), new PriceSetter());
        }

        [Fact]
        public void Constructor_Should_Throw_ArgumentException_When_Context_Parameter_Null()
        {
            Assert.Throws<ArgumentException>(() =>
                new PointOfSaleTerminal(null, new PriceCalculator(), new PriceSetter()));
        }

        [Theory]
        [InlineData(new[] { "A", "B", "C", "D", "A", "B", "A" }, 13.25)]
        [InlineData(new[] { "C", "C", "C", "C", "C", "C", "C" }, 6)]
        [InlineData(new[] { "A", "B", "C", "D" }, 7.25)]
        public void GetTotalPrices_For_OneOrMoreProducts(string[] products, decimal expectedTotalPrice)
        {
            // Act
            foreach (string product in products)
            {
                _terminal.ScanProduct(product);
            }

            // Assert
            Assert.Equal(expectedTotalPrice, _terminal.GetTotalPrice());
        }

        [Fact]
        public void Throw_ProductDoesNotExist_Exception_When_Product_Unknown()
        {
            Assert.Throws<ProductDoesNotExist>(() => _terminal.ScanProduct("G"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ScanProduct_Should_Throw_ArgumentException_When_ProductCode_Null_Or_Empty(string productCode)
        {
            Assert.Throws<ArgumentException>(() => _terminal.ScanProduct(productCode));
        }

        [Fact]
        public void SetPricing_Should_Throw_ArgumentException_When_Products_Null_Or_Empty()
        {
            Assert.Throws<ArgumentException>(() => _terminal.SetPricing(null));
            Assert.Throws<ArgumentException>(() => _terminal.SetPricing(new List<ProductDto>()));
        }
    }
}
