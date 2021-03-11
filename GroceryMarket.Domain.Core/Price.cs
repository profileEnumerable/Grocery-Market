namespace GroceryMarket.Domain.Core
{
    public class Price
    {
        public int Id { get; set; }
        public decimal PricePerUnit { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
