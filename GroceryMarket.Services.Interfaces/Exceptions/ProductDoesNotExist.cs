using System;

namespace GroceryMarket.Services.Exceptions
{
    public class ProductDoesNotExist : Exception
    {
        public ProductDoesNotExist(string message) : base(message)
        {
        }
    }
}
