using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Internal;
using Microsoft.Extensions.Time.Testing;
using NSubstitute;
using Xunit;

namespace Apress.UnitTests.DateTimes;

public class DateUtilitiesTests
{
    private readonly Fixture _fixture;

    public DateUtilitiesTests()
    {
        _fixture = new Fixture();
        _fixture.Customizations.Add(new RandomNumericSequenceGenerator(0, 11));
    }


    [Fact]
    public void IsAfternoon_WhenCurrentDateTimeIsBeforeNoon_ShouldReturnFalse_ISystemClock()
    {
        // Arrange
        var systemClockMock = Substitute.For<ISystemClock>();
        var hour = _fixture.Create<int>();
        var mockTime = new DateTimeOffset(new DateTime(2025, 2, 17, hour, 0, 0));
        systemClockMock.UtcNow.Returns(mockTime);
        var sut = new DateUtilities1(systemClockMock);

        // Act
        var result = sut.IsAfternoon();

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void IsAfternoon_WhenCurrentDateTimeIsBeforeNoon_ShouldReturnFalse_TimeProvider()
    {
        // Arrange
        var fakeTimeProvider = new FakeTimeProvider();
        var hour = _fixture.Create<int>();
        var mockTime = new DateTimeOffset(new DateTime(2025, 2, 17, hour, 0, 0));
        fakeTimeProvider.SetUtcNow(new DateTimeOffset(new DateTime(2025, 2, 17, hour, 0, 0)));
        var sut = new DateUtilities2(fakeTimeProvider);

        // Act
        var result = sut.IsAfternoon();

        // Assert
        result.Should().BeFalse();
    }
}
