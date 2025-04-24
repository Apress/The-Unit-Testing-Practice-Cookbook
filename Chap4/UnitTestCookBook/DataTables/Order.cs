using Apress.UnitTests.DataTables.Helpers;
using System.Text.Json.Serialization;

namespace Apress.UnitTests.DataTables;

public class Order
{
    public long Id { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
}
