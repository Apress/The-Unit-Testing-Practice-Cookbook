using Apress.UnitTests.TestableApp.Domain.Orders;
using Apress.UnitTests.TestableApp.Infrastructure.EfCore.Database;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
namespace Apress.UnitTests.TestableApp.Infrastructure.EfCore.Orders;

[ExcludeFromCodeCoverage]
public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        return (await _context.Orders.Where(x => x.Id == id).SingleAsync()).FromEntity();
    }

    public async Task<int> AddAsync(Order order)
    {
        var entity = order.ToEntity();
        if (entity is null)
            return 0;

        _context.Orders.Add(entity);
        return await _context.SaveChangesAsync();
    }
}
