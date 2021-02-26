namespace GroceryMarket.Services.Interfaces
{
    public interface IPointOfSaleTerminal
    {
        void ScanProduct(string productName);
        double? CalculateTotalPrice();
    }
}
