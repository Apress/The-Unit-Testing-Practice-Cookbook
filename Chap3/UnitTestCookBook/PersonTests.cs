using Apress.UnitTests.Models;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Apress.UnitTests;

public class PersonTests
{
    [Fact]
    public void Person_WhenPersonIsCorrectlyInstantiated_ShouldReturnFirstNameAndLastNameAndFullNameCorrectlyFilled()
    {
        // Arrange
        var person = new Person("Anthony", "Giretti");

        // Assert with Fluent Assertions
        person.FirstName.Should().Be("Anthony");
        person.LastName.Should().Be("Giretti");
        person.FullName.Should().Be("Anthony Giretti");

        // Chained assertion with Fluent Assertions
        person.FullName.Should().Contain("Anthony").And.Contain("Giretti");

        // Comapring with xUnit assertions
        Assert.Equal("Anthony", person.FirstName);
        Assert.Equal("Giretti", person.LastName);
        Assert.Equal("Anthony Giretti", person.FullName);
    }
}
