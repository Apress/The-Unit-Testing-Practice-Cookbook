namespace Apress.UnitTests.TestableApp.Domain.Orders;

public interface IOrderValidator
{
    List<string> Validate(Order order);
}
