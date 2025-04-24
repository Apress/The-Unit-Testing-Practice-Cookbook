using Apress.UnitTests.Models;
using AutoFixture;
using FluentAssertions;
using System.Diagnostics.Metrics;
using Xunit;

namespace Apress.UnitTests;

// AutoFixture, FluentAssertions
public class AddressTests
{
    private readonly Fixture _fixture;

    public AddressTests()
    {
        _fixture = new Fixture();   
    }

    [Fact]
    public void Display_WhenAddressIsSetWithApartmentNumber_ShouldDisplayAddressWithApartementNumberCorrectly()
    {
        // Arrange
        var address = _fixture.Build<Address>()
                              .With(x => x.Country, "Canada")
                              .Create();
        var person = _fixture.Create<Person>();

        // Act
        var displayedAddress = address.Display(person);

        // Assert
        displayedAddress.Should().Be($"{person.FullName} lives at {address.StreetNumber} {address.Street} {address.ApartmentNumber}, {address.City}, {address.State}, {address.ZipCode}, {address.Country}");
    }

    [Fact]
    public void Display_WhenAddressIsNotSetWithApartmentNumber_ShouldDisplayAddressWithoutApartementNumberCorrectly()
    {
        var address = _fixture.Build<Address>()
                      .Without(x => x.ApartmentNumber)
                      .Create();
        var person = _fixture.Create<Person>();

        // Act
        var displayedAddress = address.Display(person);

        // Assert
        displayedAddress.Should().Be($"{person.FullName} lives at {address.StreetNumber} {address.Street}, {address.City}, {address.State}, {address.ZipCode}, {address.Country}");
    }
}
