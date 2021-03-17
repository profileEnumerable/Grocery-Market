using GroceryMarket.Domain.Core;
using GroceryMarket.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using GroceryMarket.Services.DTOs;

namespace GroceryMarket.Services
{
    public class PriceSetter : IPriceSetter
    {
        public void SetProductsPricing(IEnumerable<ProductDto> products, ProductContext context)
        {
            foreach (ProductDto productDto in products)
            {
                Product matchedProduct = context.Products.FirstOrDefault(p => p.Name == productDto.Name);

                if (matchedProduct != null)
                {
                    context.Entry(matchedProduct)
                        .Reference(p => p.Discount).Load();

                    context.Entry(matchedProduct)
                        .Reference(p => p.Price).Load();

                    matchedProduct.Price.PricePerUnit = productDto.Price.PricePerUnit;

                    if (productDto.Discount != null)
                    {
                        matchedProduct.Discount.VolumePrice = productDto.Discount.VolumePrice;
                        matchedProduct.Discount.QuantityForDiscount = productDto.Discount.QuantityForDiscount;
                    }
                }
                else
                {
                    //TODO:Add auto mapper
                    var newProduct = new Product
                    {
                        Name = productDto.Name,
                        Price = new Price() { PricePerUnit = productDto.Price.PricePerUnit },
                    };

                    if (productDto.Discount != null)
                    {
                        newProduct.Discount = new Discount()
                        {
                            VolumePrice = productDto.Discount.VolumePrice,
                            QuantityForDiscount = productDto.Discount.QuantityForDiscount
                        };
                    }

                    context.Add(newProduct);
                }
            }
            context.SaveChanges();
        }
    }
}
