using Apress.UnitTests.DataTables.Helpers;
using ExpectedObjects;
using NSubstitute;
using System.Data;
using Xunit;

namespace Apress.UnitTests.DataTables;

public class OrderServiceTests
{
    [Fact]
    public async Task GetAsync_WhenGetAsyncRepositoryMethodReturnAFilledDataTable_GetAsyncServiceMethodReturnsAListOfTransactions()
    {
        // Arrange
        IOrderRepository orderRepositoryMock = Substitute.For<IOrderRepository>();
        DataTable table = new DataTable();
        table.Columns.Add("Id", typeof(long));
        table.Columns.Add("Quantity", typeof(int));
        table.Columns.Add("Date", typeof(DateTime));

        var datatable = EmbeddedJsonFileHelper.GetContent<DataTable>(@"DataTables\datatable");
        foreach (DataRow row in datatable.Rows)
        {
            table.ImportRow(row);
        }

        orderRepositoryMock.GetAsync().Returns(x => table);
        var expectedResult = new List<Order>
        {
            new Order { Id = 1, Quantity = 10, Date = DateTime.Parse("2025-01-20") },
            new Order { Id = 2, Quantity = 20, Date = DateTime.Parse("2025-02-12")},
            new Order { Id = 3, Quantity = 30, Date = DateTime.Parse("2025-02-02")}
        }.ToExpectedObject();

        // Act
        var service = new OrderService(orderRepositoryMock);
        var result = await service.GetAsync();

        // Assert
        expectedResult.ShouldEqual(result);
    }
}
