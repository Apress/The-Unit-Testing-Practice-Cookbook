using Apress.UnitTests.TestableApp.Domain.Orders;
using Apress.UnitTests.TestableApp.Infrastructure.EfCore.Orders;
using AutoFixture;
using ExpectedObjects;
using FluentAssertions;
using Xunit;

namespace Apress.UnitTests.Infrastructure.OrderEntityMapperTests;

public class FromEntityTests
{
    private readonly Fixture _fixture;

    public FromEntityTests()
    {
        _fixture = new Fixture();
    }

    [Fact]
    public void FromEntity_WhenOrderEntityIsNull_ShouldReturnNullOrder()
    {
        // Arrange
        var orderEntity = (OrderEntity)null;

        // Act
        var result = orderEntity.FromEntity();

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public void FromEntity_WhenOrderEntityIsNotNull_ShouldReturnOrderCorrectlyFilled()
    {
        // Arrange
        var orderEntity = _fixture.Create<OrderEntity>();

        // Act
        var result = orderEntity.FromEntity();

        // Assert
        result.ToExpectedObject().ShouldEqual(new Order
        {
            Id = orderEntity.Id,
            ProductName = orderEntity.ProductName,
            Price = orderEntity.Price
        });
    }
}
