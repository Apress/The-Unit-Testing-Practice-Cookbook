using AutoFixture;
using FluentAssertions;
using System.Reflection;
using Xunit;

namespace Apress.UnitTests.PrivateMethods;

public class UserTests
{
    [Fact]
    public void GetUserName_WhenGetUserNameIsInvoked_ShouldReturnUserNameProperly()
    {
        // Arrange
        var fixture = new Fixture();
        var firstname = fixture.Create<string>();
        var lastname = fixture.Create<string>();

        Type type = typeof(User);
        var user = Activator.CreateInstance(type, firstname, lastname);
        MethodInfo method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
        .Where(x => x.Name == "GetUserName" && x.IsPrivate)
        .First();

        //Act
        var getUserName = (string)method.Invoke(user, null);

        //Assert
        getUserName
        .Should()
        .Be($"{firstname} {lastname}");
    }
}
