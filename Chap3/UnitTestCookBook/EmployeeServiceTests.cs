using Apress.UnitTests.Interfaces;
using Apress.UnitTests.Models;
using Apress.UnitTests.Services;
using AutoFixture;
using ExpectedObjects;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Apress.UnitTests;

// ExpectedObjects
public class EmployeeServiceTests
{
    private readonly Fixture _fixture;
    private readonly IUserRepository _userRepositoryMock;
    private readonly ILogAccessService _logAccessServiceMock;
    private readonly EmployeeService _sut;

    public EmployeeServiceTests()
    {
        _fixture = new Fixture();
        _userRepositoryMock = Substitute.For<IUserRepository>();
        _logAccessServiceMock = Substitute.For<ILogAccessService>();
        _sut = new EmployeeService(_userRepositoryMock, _logAccessServiceMock);
    }

    [Fact]
    public async Task GetByIdAsync_WhenGetByIdAsyncReturnANonNullUser_ShouldReturnAnEmployeeObjectCorrectlyFilledAndInvokeLogAsync()
    {
        // Arrange
        var id = _fixture.Create<int>();
        var user = _fixture.Create<User>();
        _userRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns(user);
        var expectedEmployee = new Employee
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            IsActive = user.IsActive,
            CompanyName = "MyCompany"
        }.ToExpectedObject();

        // Act
        var employee = await _sut.GetByIdAsync(id);

        // Assert
        expectedEmployee.Equals(employee);
        await _logAccessServiceMock.Received(1).LogAsync(Arg.Is<Employee>(emp => expectedEmployee.Equals(emp)));
    }

    [Fact]
    public async Task GetByIdAsync_WhenGetByIdAsyncReturnANonNullUser_ShouldReturnAnEmployeeObjectCorrectlyFilledAndInvokeLogAsync_WithoutExpectedObjects()
    {
        // Arrange
        var id = _fixture.Create<int>();
        var user = _fixture.Create<User>();
        _userRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns(user);
        var expectedEmployee = new Employee
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            IsActive = user.IsActive,
            CompanyName = "MyCompany"
        };

        // Act
        var employee = await _sut.GetByIdAsync(id);

        // Assert
        expectedEmployee.Equals(employee);
        await _logAccessServiceMock.Received(1).LogAsync(Arg.Is<Employee>(emp => emp.Id == expectedEmployee.Id &&
                                                                                 emp.FirstName == expectedEmployee.FirstName &&
                                                                                 emp.LastName == expectedEmployee.LastName &&
                                                                                 emp.Email == expectedEmployee.Email &&
                                                                                 emp.IsActive == expectedEmployee.IsActive &&
                                                                                 emp.CompanyName == expectedEmployee.CompanyName));
    }
}
