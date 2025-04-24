using Apress.UnitTests.TestableApp.Domain.Common;
using Apress.UnitTests.TestableApp.Domain.Orders;

namespace Apress.UnitTests.TestableApp.Services.Orders;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderValidator _orderValidator;

    public OrderService(IOrderRepository orderRepository, IOrderValidator orderValidator)
    {
        _orderRepository = orderRepository;
        _orderValidator = orderValidator;
    }

    public async Task<(Statuses, Order, List<string>)> GetByIdAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);

        if (order == null)
            return (Statuses.NotFound, null, new List<string> { "Order not found." });

        return (Statuses.Success, order, new List<string>());
    }

    public async Task<(Statuses, int?, List<string>)> CreateAsync(Order order)
    {
        var validationErrors = _orderValidator.Validate(order);
        if (validationErrors.Count > 0)
            return (Statuses.Invalid, null, validationErrors);

        var id = await _orderRepository.AddAsync(order);

        return (Statuses.Success, id, new List<string>());
    }
}