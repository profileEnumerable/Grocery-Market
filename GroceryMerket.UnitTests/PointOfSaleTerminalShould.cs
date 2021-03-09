using GroceryMarket.Services;
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
        public void GetTotalPrice_Should_Return_Zero_When_Basket_Empty()
        {
            // Assert 
            Assert.Equal(0, _terminal.GetTotalPrice());
        }

        [Theory]
        [InlineData("G")]
        [InlineData(" ")]
        public void Throw_ProductDoesNotExist_Exception_When_Product_Unknown(string productCode)
        {
            // Assert
            Assert.Throws<ProductDoesNotExist>(() => _terminal.ScanProduct(productCode));
        }
    }
}
