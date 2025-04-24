using System.Diagnostics.CodeAnalysis;

namespace Apress.UnitTests.TestableApp.Infrastructure.EfCore.Orders;

[ExcludeFromCodeCoverage]
public class OrderEntity
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
}
