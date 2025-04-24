using Apress.UnitTests.TestableApp.Domain.Orders;

namespace Apress.UnitTests.TestableApp.Infrastructure.EfCore.Orders;

public static class OrderEntityMapper
{
    public static OrderEntity ToEntity(this Order order)
    {
        if (order is null)
            return null;

        return new()
        {
            Id = order.Id,
            ProductName = order.ProductName,
            Price = order.Price,
        };
    }

    public static Order FromEntity(this OrderEntity orderEntity)
    {
        if (orderEntity is null)
            return null;

        return new()
        {
            Id = orderEntity.Id,
            ProductName = orderEntity.ProductName,
            Price = orderEntity.Price,
        };
    }
}
