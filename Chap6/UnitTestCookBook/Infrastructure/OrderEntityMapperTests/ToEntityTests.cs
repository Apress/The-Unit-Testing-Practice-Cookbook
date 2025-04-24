using Apress.UnitTests.TestableApp.Domain.Orders;
using Apress.UnitTests.TestableApp.Infrastructure.EfCore.Orders;
using AutoFixture;
using ExpectedObjects;
using FluentAssertions;
using Xunit;

namespace Apress.UnitTests.Infrastructure.OrderEntityMapperTests;

public class ToEntityTests
{
    private readonly Fixture _fixture;

    public ToEntityTests()
    {
        _fixture = new Fixture();
    }

    [Fact]
    public void ToEntity_WhenOrderIsNull_ShouldReturnNull()
    {
        // Arrange
        var order = (Order)null;

        // Act
        var result = order.ToEntity();

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public void ToEntity_WhenOrderIsNotNull_ShouldReturnOrderEntityCorrectlyFilled()
    {
        // Arrange
        var order = _fixture.Create<Order>();

        // Act
        var result = order.ToEntity();

        // Assert
        result.ToExpectedObject().ShouldEqual(new OrderEntity
        {
            Id = order.Id,
            ProductName = order.ProductName,
            Price = order.Price
        });
    }

}
