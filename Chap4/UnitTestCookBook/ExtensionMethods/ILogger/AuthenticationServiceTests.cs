using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Testing;
using NSubstitute;
using Xunit;

namespace Apress.UnitTests.ExtensionMethods;

public class AuthServiceTests
{
    [Fact]
    public void Login_WhenLoginIsInvoked_Should_InvokeLoggerWithCorrectParameters()
    {
        // Arrange
        var fixture = new Fixture();
        var logger = Substitute.For<ILogger<AuthService>>();
        var authService = new AuthService(logger);
        var userId = fixture.Create<string>();

        // Act
        authService.Login(userId);

        // Assert
        logger.Received(1).Log(
            LogLevel.Information,             // Ensure it's an Information log
            Arg.Any<EventId>(),               // Ignore EventId
            Arg.Is<object>(o =>
                o.ToString().Equals($"User {userId} has logged in") // Ensure correct message template and its parameters
            ),
            Arg.Any<Exception>(),             // Ignore exceptions
            Arg.Any<Func<object, Exception, string>>() // Ignore formatter
        );
    }

    [Fact]
    public void Login_WhenLoginIsInvoked_Should_InvokeLoggerWithCorrectParameters_FakeLogger()
    {
        // Arrange
        var fixture = new Fixture();
        var logger = new FakeLogger<AuthService>();
        var authService = new AuthService(logger);
        var userId = fixture.Create<string>();

        // Act
        authService.Login(userId);

        // Assert
        logger.Collector.LatestRecord.Level.Should().Be(LogLevel.Information);
        logger.Collector.LatestRecord.Message.Should().Be($"User {userId} has logged in");
    }
}
