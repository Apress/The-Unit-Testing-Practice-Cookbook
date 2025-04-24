using System.Data;

namespace Apress.UnitTests.DataTables;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<Order>> GetAsync()
    {
        var table = await _orderRepository.GetAsync();
        var orders = new List<Order>();

        foreach (DataRow row in table.Rows)
        {
            var order = new Order
            {
                Id = row.Field<long>("Id"),
                Quantity = row.Field<int>("Quantity"),
                Date = row.Field<DateTime>("Date")
            };

            orders.Add(order);
        }
        return orders;
    }
}
