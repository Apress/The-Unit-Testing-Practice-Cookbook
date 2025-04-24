using Apress.UnitTestCookbook.SampleApp.Models;

namespace Apress.UnitTestCookbook.SampleApp.Interfaces;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
    Task<int> DeleteByIdAsync(int id);
}
