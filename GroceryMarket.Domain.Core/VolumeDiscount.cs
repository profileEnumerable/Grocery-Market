namespace GroceryMarket.Domain.Core
{
    public class VolumeDiscount
    {
        public int Id { get; set; }
        public decimal VolumePrice { get; set; }
        /// <summary>
        /// Define a quantity of product that can be calculated
        /// with volume discount
        /// </summary>
        public int QuantityForDiscount { get; set; }

        public int ProductId  { get; set; }

        public Product Product { get; set; }
    }
}
