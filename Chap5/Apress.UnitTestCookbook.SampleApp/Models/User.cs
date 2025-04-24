using System.Diagnostics.CodeAnalysis;

namespace Apress.UnitTestCookbook.SampleApp.Models;

[ExcludeFromCodeCoverage]
public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
}
