using System;

namespace GroceryMarket.Infrastructure.Business.Exceptions
{
    public class ProductDoesNotExist : Exception
    {
        public ProductDoesNotExist(string message) : base(message)
        {
        }
    }
}
