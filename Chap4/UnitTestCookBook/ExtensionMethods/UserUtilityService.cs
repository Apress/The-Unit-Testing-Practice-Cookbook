namespace Apress.UnitTests.ExtensionMethods;

public interface IUserUtilityService
{
    string GetUserName(User user);
}

public class UserUtilityService : IUserUtilityService
{
    public string GetUserName(User user)
    {
        if (user == null)
            return null;
        return $"{user.FirstName}{user.FirstName}";
    }
}
