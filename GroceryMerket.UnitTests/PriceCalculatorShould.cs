using System.Collections.Generic;
using GroceryMarket.Domain.Core;
using GroceryMarket.Services;
using Xunit;

namespace GroceryMarket.UnitTests
{
    public class PriceCalculatorShould
    {
        private readonly PriceCalculator _calculator;
        public PriceCalculatorShould()
        {
            _calculator = new PriceCalculator();
        }

        [Fact]
        public void CalculateTotalPrice_Should_Return_Zero_When_Basket_Empty()
        {
            //Arrange
            var basket = new Dictionary<Product, int>();

            //Assert
            Assert.Equal(0, _calculator.CalculateTotalPrice(basket));
        }
    }
}
