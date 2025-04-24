namespace Apress.UnitTests.ExtensionMethods;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserUtilityService _userExtensions;

    public UserService(IUserRepository userRepository,
                       IUserUtilityService userExtensions)
    {
        _userRepository = userRepository;
        _userExtensions = userExtensions;
    }

    public async Task<string> GetUserName(int id)
    {
        if (id > 0)
            return _userExtensions.GetUserName(await _userRepository.GetByIdAsync(id));
        return await Task.FromResult<string>(null);
    }
}
