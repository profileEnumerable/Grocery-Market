namespace GroceryMarket.Domain.Core
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public Price ProductPrice { get; set; } 
    }
}
