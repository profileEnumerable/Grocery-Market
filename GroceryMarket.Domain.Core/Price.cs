namespace GroceryMarket.Domain.Core
{
    public class Price
    {
        public int Id { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal VolumePrice { get; set; }
        /// <summary>
        /// Define a quantity of product that can be calculated
        /// with volume discount
        /// </summary>
        public int VolumeDiscountUnit { get; set; }
    }
}
