using Apress.UnitTests.Models;

namespace Apress.UnitTests.Interfaces;

public interface ILogAccessService
{
    Task LogAsync(Employee person);
}
