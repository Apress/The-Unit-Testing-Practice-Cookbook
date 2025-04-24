using Apress.UnitTests.Internal;
using FluentAssertions;
using Xunit;

namespace Apress.UnitTests.InternalClasses;

public class StringHelpersTests
{
    [Fact]
    public void Capitalize_WhenAnInputIsProvidedtoCapitalizeMethod_ShouldCapitalizeCorrectlyInput()
    {
        // Arrange
        var input = "anthony";

        // Act
        var result = StringHelpers.Capitalize(input);

        // Assert
        result.Should().Be("Anthony");
    }
}
