using GroceryMarket.Domain.Core;
using GroceryMarket.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace GroceryMarket.Services
{
    public class PriceSetter : IPriceSetter
    {
        public void SetPricing(IEnumerable<Product> products, ProductContext context)
        {
            foreach (Product product in products)
            {
                Product matchedProduct = context.Products.FirstOrDefault(p => p.Name == product.Name);

                if (matchedProduct != null)
                {
                    context.Entry(matchedProduct)
                        .Reference(p => p.Discount).Load();

                    context.Entry(matchedProduct)
                        .Reference(p => p.Price).Load();

                    matchedProduct.Price.PricePerUnit = product.Price.PricePerUnit;

                    if (product.Discount != null)
                    {
                        matchedProduct.Discount.VolumePrice = product.Discount.VolumePrice;
                        matchedProduct.Discount.QuantityForDiscount = product.Discount.QuantityForDiscount;
                    }
                }
                else
                {
                    context.Add(product);
                }
            }
            context.SaveChanges();
        }
    }
}
