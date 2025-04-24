using AutoFixture;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Apress.UnitTests.AbstractClasses;

public class EmployeeTests
{
    [Fact]
    public void DisplayInfo_TestCalculateSalaryAndDisplayInfo()
    {
        var fixture = new Fixture();
        var name = fixture.Create<string>();
        var id = fixture.Create<int>();
        var employeeSubstitute = Substitute.ForPartsOf<Employee>(name, id);

        // Act
        string info = employeeSubstitute.DisplayInfo();

        // Assert
        info.Should().Be($"Employee Name: {name}, Id: {id}");
    }
}
