using Apress.UnitTestCookbook.SampleApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Apress.UnitTestCookbook.SampleApp.Controllers;

[ExcludeFromCodeCoverage]
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userService;

    public UserController(IUserRepository userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await _userService.GetByIdAsync(id);
        return Ok(order);
    }
}
