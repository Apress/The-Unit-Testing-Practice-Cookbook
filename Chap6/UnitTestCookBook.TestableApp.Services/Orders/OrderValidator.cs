using Apress.UnitTests.TestableApp.Domain.Orders;

namespace Apress.UnitTests.TestableApp.Services.Orders;

public class OrderValidator : IOrderValidator
{
    public List<string> Validate(Order order)
    {
        var errors = new List<string>();

        if (order == null)
        {
            errors.Add("Order cannot be null.");
            return errors;
        }
        if (string.IsNullOrWhiteSpace(order.ProductName))
        {
            errors.Add("Product name is required.");
        }
        if (order.Price <= 0)
        {
            errors.Add("Price must be greater than zero.");
        }

        return errors;
    }
}