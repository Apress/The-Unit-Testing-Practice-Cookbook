using Xunit;

namespace Apress.UnitTests;

// xUnit
public class ComputeTests
{
    private int myNumber;

    public ComputeTests()
    {
        myNumber = 1;
    }

    [Fact]
    public void WhenOneIsAddedToOne_ShouldReturnTwo()
    {
        // Arrange
        int valueToAdd = 1;

        // Act
        myNumber += valueToAdd;

        // Assert
        Assert.Equal(2, myNumber);
    }

    [Fact]
    public void WhenOneIsSubstractedToOne_ShouldReturn0()
    {
        // Arrange
        int valueToSubstract = 1;

        // Act
        myNumber -= valueToSubstract;

        // Assert
        Assert.Equal(0, myNumber);
    }
}
