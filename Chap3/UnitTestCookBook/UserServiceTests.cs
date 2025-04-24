using Apress.UnitTests.Interfaces;
using Apress.UnitTests.Models;
using Apress.UnitTests.Services;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Apress.UnitTests;

// AutoFixture, FluentAssertions
public class UserServiceTests
{
    private readonly Fixture _fixture;
    private readonly IUserRepository _userRepositoryMock;
    private readonly UserService _sut;

    public UserServiceTests()
    {
        _fixture = new Fixture();
        _userRepositoryMock = Substitute.For<IUserRepository>();
        _sut = new UserService(_userRepositoryMock);
        _fixture.Customizations.Add(new RandomNumericSequenceGenerator(1, int.MaxValue));
    }

    [Fact]
    public async Task GetByIdAsync_WhenIdIsLowerOrEqualsZero_ShouldReturnNullAndRepositoryShouldNotBeInvoked()
    {
        // Arrange
        _fixture.Customizations.Clear();
        _fixture.Customizations.Add(new RandomNumericSequenceGenerator(int.MinValue, 0));
        var id = _fixture.Create<int>();

        // Act
        var user = await _sut.GetByIdAsync(id);

        // Assert
        user.Should().BeNull();
        await _userRepositoryMock.DidNotReceive().GetByIdAsync(Arg.Any<int>());
    }

    [Fact]
    public async Task GetByIdAsync_WhenIdIsGreaterThanZero_ShouldReturnUserObjectAndRepositoryShouldBeInvokedWithTheRightParameters()
    {
        // Arrange
        var id = _fixture.Create<int>();
        var user = _fixture.Create<User>();
        _userRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns(user);

        // Act
        var result = await _sut.GetByIdAsync(id);

        // Assert
        user.Should().Be(user);
        await _userRepositoryMock.Received(1).GetByIdAsync(Arg.Is(id));
    }

    [Fact]
    public async Task WhenIdIsGreaterThanZeroAndUserRepositoryReturnsNull_ShouldReturnNull()
    {
        // Arrange
        var id = _fixture.Create<int>();
        _userRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns((User)null);

        // Act
        var user = await _sut.GetByIdAsync(id);

        // Assert
        user.Should().BeNull();
        await _userRepositoryMock.Received(1).GetByIdAsync(Arg.Is(id));
    }

    [Fact]
    public async Task WhenAListOfUserIdIsProvidedAndSomeAreNotDeleted_ShouldReturnFalseAndInvokeDeleteByIdAsyncForEachUserId()
    {
        // Arrange
        var ids = _fixture.CreateMany<int>(2);
        var firstId = ids.First();
        var lastId = ids.Last();

        _userRepositoryMock.DeleteByIdAsync(Arg.Is(firstId)).Returns(1);
        _userRepositoryMock.DeleteByIdAsync(Arg.Is(lastId)).Returns(0);

        // Act
        var result = await _sut.DeleteByIdsAsync(ids);

        // Assert
        result.Should().BeFalse();
        await _userRepositoryMock.Received(1).DeleteByIdAsync(Arg.Is(firstId));
        await _userRepositoryMock.Received(1).DeleteByIdAsync(Arg.Is(lastId));
    }
}
