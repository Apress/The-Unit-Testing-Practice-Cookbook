using Apress.UnitTests.Interfaces;
using Apress.UnitTests.Models;

namespace Apress.UnitTests.Services;

public class EmployeeService
{
    private readonly IUserRepository _userRepository;
    private readonly ILogAccessService _logService;

    public EmployeeService(IUserRepository userRepository, ILogAccessService logService)
    {
        _userRepository = userRepository;
        _logService = logService;
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        
        if (user is null)
            return null;
        else
        {
            var employee = new Employee
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                IsActive = user.IsActive,
                CompanyName = "MyCompany"
            };
            await _logService.LogAsync(employee);
            return employee;
        }
    }
}
