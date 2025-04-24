namespace Apress.UnitTests.ExtensionMethods;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
}