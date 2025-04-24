using Apress.UnitTests.TestableApp.Domain.Orders;
using Apress.UnitTests.TestableApp.Services.Orders;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Apress.UnitTests.Services.Orders.OrderValidatorTests;

public class ValidateTests
{
    private readonly OrderValidator _validator;
    private readonly Fixture _fixture;

    public ValidateTests()
    {
        _validator = new OrderValidator();
        _fixture = new Fixture();
    }

    [Fact]
    public void Validate_WhenOrderIsNull_ShouldReturnSingleOrderCannotBeNullError()
    {
        // Arrange
        var order = (Order)null;

        // Act
        var errors = _validator.Validate(order);

        // Assert
        errors.Should().ContainSingle("Order cannot be null.");
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Validate_WhenOrderIsNotNullAndProductNameIsNullOrEmpty_ShouldReturnASingleSpecificError(string productName)
    {
        // Arrange
        var order = _fixture.Build<Order>()
                            .With(o => o.ProductName, productName)
                            .Create();

        // Act
        var errors = _validator.Validate(order);

        // Assert
        errors.Should().ContainSingle("Product name is required.");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Validate_WhenOrderIsNotNullAndPriceEqualsZeroOrNegative_ShouldReturnASingleSpecificError(decimal price)
    {
        // Arrange
        var order = _fixture.Build<Order>()
                            .With(o => o.Price, price)
                            .Create();

        // Act
        var errors = _validator.Validate(order);

        // Assert
        errors.Should().ContainSingle("Price must be greater than zero.");
    }

    [Theory]
    [InlineData("", 0)]
    [InlineData(" ", 0)]
    [InlineData(null, 0)]
    [InlineData("", -1)]
    [InlineData(" ", -1)]
    [InlineData(null, -1)]
    public void Validate_WhenOrderIsNotNullAndPriceEqualsZeroOrNegativeAndProductNameIsNullOrEmpty_ShouldReturnTwoSpecificErrors(string productName, decimal price)
    {
        // Arrange
        var order = _fixture.Build<Order>()
                            .With(o => o.Price, price)
                            .With(o => o.ProductName, productName)
                            .Create();

        // Act
        var errors = _validator.Validate(order);

        // Assert
        errors.Should()
              .HaveCount(2)
              .And
              .Contain("Price must be greater than zero.")
              .And
              .Contain("Product name is required.");
    }

    [Fact]
    public void Validate_WhenOrderIsNotNullAndCorrectlyFilled_ShouldReturnEmptyErrorList()
    {
        // Arrange
        var order = _fixture.Create<Order>();

        // Act
        var errors = _validator.Validate(order);

        // Assert
        errors.Should().BeEmpty();
    }
}
