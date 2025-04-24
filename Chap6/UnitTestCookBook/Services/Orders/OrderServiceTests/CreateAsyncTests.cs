using Apress.UnitTests.TestableApp.Domain.Common;
using Apress.UnitTests.TestableApp.Domain.Orders;
using Apress.UnitTests.TestableApp.Services.Orders;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Apress.UnitTests.Services.Orders.OrderServiceTests;

public class CreateAsyncTests
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderValidator _orderValidator;
    private readonly IOrderService _orderService;
    private readonly Fixture _fixture;

    public CreateAsyncTests()
    {
        _orderRepository = Substitute.For<IOrderRepository>();
        _orderValidator = Substitute.For<IOrderValidator>();
        _orderService = new OrderService(_orderRepository, _orderValidator);
        _fixture = new Fixture();
    }

    [Fact]
    public async Task CreateAsync_WhenValidationReturnsAnError_ShouldReturnInvalidAndIdNullAndProperError()
    {
        // Arrange
        var order = _fixture.Create<Order>();
        _orderValidator.Validate(order).Returns(new List<string> { "A single error." });

        // Act
        var (status, id, errors) = await _orderService.CreateAsync(order);

        // Assert
        status.Should().Be(Statuses.Invalid);
        id.Should().BeNull();
        errors.Should().ContainSingle("Invalid data.");
        _orderValidator.Received(1).Validate(Arg.Is(order));
        await _orderRepository.DidNotReceive().AddAsync(Arg.Any<Order>());
    }

    [Fact]
    public async Task CreateAsync_WhenValidationReturnsSeveralErrors_ShouldReturnInvalidAndIdNullAndAllProperErrors()
    {
        // Arrange
        var order = _fixture.Create<Order>();
        _orderValidator.Validate(order).Returns(new List<string> { "Error1.", "Error2." });

        // Act
        var (status, id, errors) = await _orderService.CreateAsync(order);

        // Assert
        status.Should().Be(Statuses.Invalid);
        id.Should().BeNull();
        errors.Should()
              .HaveCount(2)
              .And
              .Contain("Error1.")
              .And.
              Contain("Error2.");
        _orderValidator.Received(1).Validate(Arg.Is(order));
        await _orderRepository.DidNotReceive().AddAsync(Arg.Any<Order>());
    }

    [Fact]
    public async Task CreateAsync_WhenValidationReturnsNoError_ShouldReturnIdNotNullAndSuccessAndEmptyError()
    {
        // Arrange
        var order = _fixture.Create<Order>();
        var orderId = _fixture.Create<int>();
        _orderValidator.Validate(order).Returns(new List<string>());
        _orderRepository.AddAsync(order).Returns(orderId);

        // Act
        var (status, id, errors) = await _orderService.CreateAsync(order);

        // Assert
        status.Should().Be(Statuses.Success);
        id.Should().Be(orderId);
        _orderValidator.Received(1).Validate(Arg.Is(order));
        await _orderRepository.Received(1).AddAsync(Arg.Is(order));
    }
}
