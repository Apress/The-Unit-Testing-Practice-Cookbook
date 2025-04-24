using Apress.UnitTests.TestableApp.Infrastructure.EfCore.Orders;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Apress.UnitTests.TestableApp.Infrastructure.EfCore.Database;

[ExcludeFromCodeCoverage]
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<OrderEntity> Orders { get; set; }
}
