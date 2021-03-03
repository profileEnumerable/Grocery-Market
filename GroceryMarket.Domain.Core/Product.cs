namespace GroceryMarket.Domain.Core
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal PricePerUnit { get; set; }
        public VolumeDiscount VolumeDiscount { get; set; } 
    }
}
