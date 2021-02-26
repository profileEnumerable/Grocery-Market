using System;
using GroceryMarket.Infrastructure.Data;

namespace GroceryMarket.UnitTests.Fixtures
{
    public class EfContextFixture : IDisposable
    {
        public ProductContext Context { get; }
        public EfContextFixture()
        {
            Context = new ProductContext();
            Context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
