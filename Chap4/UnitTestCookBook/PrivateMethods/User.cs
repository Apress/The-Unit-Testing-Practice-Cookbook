namespace Apress.UnitTests.PrivateMethods;

public class User
{
    private string _firstName { get; set; }
    private string _lastName { get; set; }

    public User(string firstName, string lastName)
    {
        _firstName = firstName;
        _lastName = lastName;
    }

    public string ValidateAndGetUserName()
    {
        if (string.IsNullOrWhiteSpace(_firstName) || string.IsNullOrWhiteSpace(_firstName))
            throw new Exception("Data is missing !");

        return this.GetUserName();
    }

    private string GetUserName() => $"{_firstName} {_lastName}";
}
