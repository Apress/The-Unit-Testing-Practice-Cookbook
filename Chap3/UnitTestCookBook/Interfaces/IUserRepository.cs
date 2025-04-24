using Apress.UnitTests.Models;

namespace Apress.UnitTests.Interfaces;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
    Task<int> DeleteByIdAsync(int id);
}
