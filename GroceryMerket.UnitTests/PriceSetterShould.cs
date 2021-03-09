using GroceryMarket.Infrastructure.Data;
using GroceryMarket.Services;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using GroceryMarket.Services.DTOs;

namespace GroceryMarket.UnitTests
{
    public class PriceSetterShould
    {
        private readonly ProductContext _productContext;
        private readonly PriceSetter _priceSetter;

        public PriceSetterShould()
        {
            _productContext = new ProductContext();
            _priceSetter = new PriceSetter();
        }

        [Fact]
        public void SetPricing_Should_Add_New_Products_To_DB()
        {
            //Arrange
            var newProduct = new List<ProductDto>()
            {
                new ProductDto
                {
                    Name = "E",
                    Price = new PriceDto { PricePerUnit = 5 }
                }
            };

            //Act
            _priceSetter.SetPricing(newProduct, _productContext);

            //Assert
            Assert.Contains(_productContext.Products, product => product.Name == "E");
        }

        [Fact]
        public void SetPricing_Should_Update_ProductPricePerUnit_When_Its_Exists_In_DB()
        {
            //Arrange
            var newProduct = new List<ProductDto>()
            {
                new ProductDto
                {
                    Name = "A",
                    Price = new PriceDto { PricePerUnit = 3 }
                }
            };

            //Act
            _priceSetter.SetPricing(newProduct, _productContext);

            //Assert
            Assert.Equal(3, _productContext.Products.First(p => p.Name == "A").Price.PricePerUnit);
        }
    }
}
