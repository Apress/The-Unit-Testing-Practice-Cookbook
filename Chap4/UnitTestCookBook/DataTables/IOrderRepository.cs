using System.Data;

namespace Apress.UnitTests.DataTables;

public interface IOrderRepository
{
    Task<DataTable> GetAsync();
}
