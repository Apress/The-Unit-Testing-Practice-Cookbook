namespace Apress.UnitTests.Models;

public class Person
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string FullName { get; private set; }

    public Person(string firstname, string lastname)
    {
        FirstName = firstname;
        LastName = lastname;
        FullName = string.Concat(firstname, " ",lastname);
    }
}
