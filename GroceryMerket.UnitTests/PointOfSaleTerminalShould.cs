using GroceryMarket.Infrastructure.Business;
using GroceryMarket.Infrastructure.Business.Exceptions;
using GroceryMarket.UnitTests.Fixtures;
using Xunit;

namespace GroceryMarket.UnitTests
{
    public class PointOfSaleTerminalShould : IClassFixture<EfContextFixture>
    {
        private readonly PointOfSaleTerminal _terminal;

        public PointOfSaleTerminalShould(EfContextFixture fixture)
        {
            _terminal = new PointOfSaleTerminal(fixture.Context);
        }

        [Theory]
        [InlineData(new string[] { "A", "B", "C", "D", "A", "B", "A" }, 13.25)]
        [InlineData(new string[] { "C", "C", "C", "C", "C", "C", "C" }, 6)]
        [InlineData(new string[] { "A", "B", "C", "D" }, 7.25)]
        public void CalculateTotalPrices_For_OneOrMoreProducts(string[] products, double expectedTotalPrice)
        {
            // Act
            foreach (string product in products)
            {
                _terminal.ScanProduct(product);
            }

            // Assert
            Assert.Equal(expectedTotalPrice, _terminal.CalculateTotalPrice());
        }

        [Fact]
        public void Return_Zero_When_Products_Empty()
        {
            // Assert 
            Assert.Equal(0, _terminal.CalculateTotalPrice());
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
