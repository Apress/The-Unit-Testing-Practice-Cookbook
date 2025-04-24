using Microsoft.Extensions.Logging;

namespace Apress.UnitTests.ExtensionMethods;

public class AuthService
{
    private readonly ILogger<AuthService> _logger;

    public AuthService(ILogger<AuthService> logger)
    {
        _logger = logger;
    }

    public void Login(string userId)
    {
        _logger.LogInformation("User {UserId} has logged in", userId);
    }
}
