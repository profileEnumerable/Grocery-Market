namespace GroceryMarket.Services.Services
{
    public interface IPointOfSaleTerminal
    {
        void ScanProduct(string productName);
        decimal GetTotalPrice();
    }
}
