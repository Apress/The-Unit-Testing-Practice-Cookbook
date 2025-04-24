namespace Apress.UnitTests.TestableApp.Domain.Orders;

public interface IOrderRepository
{
    Task<Order> GetByIdAsync(int id);
    Task<int> AddAsync(Order order);
}
