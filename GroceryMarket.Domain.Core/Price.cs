namespace GroceryMarket.Domain.Core
{
    public class Price
    {
        public int Id { get; set; }
        public double PricePerUnit { get; set; }
        public double? VolumePrice { get; set; }
        /// <summary>
        /// Define a quantity of product that can be calculated
        /// with volume discount
        /// </summary>
        public int? VolumeDiscountUnit { get; set; }

        public int ProductId  { get; set; }

        public Product Product { get; set; }
    }
}
