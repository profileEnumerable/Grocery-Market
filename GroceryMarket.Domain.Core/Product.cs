namespace GroceryMarket.Domain.Core
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public Discount Discount { get; set; }
        public Price Price { get; set; }
    }
}
