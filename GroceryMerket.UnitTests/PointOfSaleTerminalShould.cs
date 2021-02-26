using GroceryMarket.Infrastructure.Business;
using GroceryMarket.UnitTests.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace GroceryMarket.UnitTests
{
    public class PointOfSaleTerminalShould : IClassFixture<EfContextFixture>
    {
        private readonly ITestOutputHelper _output;
        private PointOfSaleTerminal _terminal;

        public PointOfSaleTerminalShould(EfContextFixture fixture, ITestOutputHelper output)
        {
            _output = output;
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
            Assert.Equal(_terminal.CalculateTotalPrice(), expectedTotalPrice);
        }
    }
}
