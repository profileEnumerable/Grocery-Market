namespace GroceryMarket.Services.DTOs
{
    public class DiscountDto
    {
        public decimal VolumePrice { get; set; }
        /// <summary>
        /// Define a quantity of product that can be calculated
        /// with volume discount
        /// </summary>
        public int QuantityForDiscount { get; set; }
    }
}
