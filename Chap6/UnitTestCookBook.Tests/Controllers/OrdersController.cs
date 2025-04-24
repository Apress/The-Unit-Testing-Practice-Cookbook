using Apress.UnitTests.TestableApp.Domain.Common;
using Apress.UnitTests.TestableApp.Domain.Orders;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Apress.UnitTests.TestableApp.Controllers;

[ExcludeFromCodeCoverage]
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var (status, order, errors) = await _orderService.GetByIdAsync(id);

        if (status == Statuses.NotFound)
            return NotFound(errors);

        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Order order)
    {
        var (status, id, errors) = await _orderService.CreateAsync(order);

        if (status == Statuses.Invalid)
            return BadRequest(errors);

        if (id <= 0)
            return UnprocessableEntity();

        return CreatedAtAction(nameof(Create), new { id }, null);
    }
}
