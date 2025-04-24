using Apress.UnitTests.Interfaces;
using Apress.UnitTests.Models;

namespace Apress.UnitTests.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        if (id > 0)
            return await _userRepository.GetByIdAsync(id);
        return await Task.FromResult<User>(null);
    }

    public async Task<bool> DeleteByIdsAsync(IEnumerable<int> ids)
    {
        foreach(int id in ids)
            if (await _userRepository.DeleteByIdAsync(id) == 0)
                return false;
        return true;
    }
}
