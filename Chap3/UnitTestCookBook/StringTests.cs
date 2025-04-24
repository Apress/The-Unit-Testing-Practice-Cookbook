using System;
using Xunit;

namespace Apress.UnitTests;

public class StringTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void IsNullOrEmpty_IsNullOrEmpty_WhenInputIsNullOrEmpty_ShouldReturnTrue(string input)
    {
        // Act
        bool result = string.IsNullOrEmpty(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_IsNullOrEmpty_WhenInputIsNotEmpty_ShouldReturnFalse()
    {
        // Arrange
        string input = "hello";

        // Act
        bool result = string.IsNullOrEmpty(input);

        // Assert
        Assert.False(result);
    }
}
