namespace GroceryMarket.Services.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; }
        public DiscountDto Discount { get; set; }
        public PriceDto Price { get; set; }
    }
}
