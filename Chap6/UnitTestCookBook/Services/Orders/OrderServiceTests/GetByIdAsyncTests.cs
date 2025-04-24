using Apress.UnitTests.TestableApp.Domain.Common;
using Apress.UnitTests.TestableApp.Domain.Orders;
using Apress.UnitTests.TestableApp.Services.Orders;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Apress.UnitTests.Services.Orders.OrderServiceTests;

public class GetByIdAsyncTests
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderValidator _orderValidator;
    private readonly IOrderService _orderService;
    private readonly Fixture _fixture;

    public GetByIdAsyncTests()
    {
        _orderRepository = Substitute.For<IOrderRepository>();
        _orderValidator = Substitute.For<IOrderValidator>();
        _orderService = new OrderService(_orderRepository, _orderValidator);
        _fixture = new Fixture();
    }

    [Fact]
    public async Task CreateAsync_WhenGetOrderByIdAsyncReturnsNull_ShouldReturnNotFoundAndNullOrderAndASingleSpecificError()
    {
        // Arrange
        var orderId = _fixture.Create<int>();
        _orderRepository.GetByIdAsync(Arg.Any<int>()).Returns((Order)null);

        // Act
        var (status, order, errors) = await _orderService.GetByIdAsync(orderId);

        // Assert
        status.Should().Be(Statuses.NotFound);
        order.Should().BeNull();
        errors.Should().ContainSingle("Order not found.");
        await _orderRepository.Received(1).GetByIdAsync(Arg.Is(orderId));
    }

    [Fact]
    public async Task CreateAsync_WhenGetOrderByIdAsyncReturnsAnOrder_ShouldReturnSuccessAndOrderAndWithAnyError()
    {
        // Arrange
        var order = _fixture.Create<Order>();
        _orderRepository.GetByIdAsync(order.Id).Returns(order);

        // Act
        var (status, resultOrder, errors) = await _orderService.GetByIdAsync(order.Id);

        // Assert
        status.Should().Be(Statuses.Success);
        resultOrder.Should().Be(order);
        errors.Should().BeEmpty();
        await _orderRepository.Received(1).GetByIdAsync(Arg.Is(order.Id));
    }
}
