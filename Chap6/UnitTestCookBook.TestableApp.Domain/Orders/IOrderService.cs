using Apress.UnitTests.TestableApp.Domain.Common;

namespace Apress.UnitTests.TestableApp.Domain.Orders;

public interface IOrderService
{
    Task<(Statuses, Order, List<string>)> GetByIdAsync(int id);
    Task<(Statuses, int?, List<string>)> CreateAsync(Order order);
}
