using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;

namespace SyncfusionJavascript.Models;


public class TestVm
{
    public PagedData<OrdersDetails> ordersDetails { get; set; }
}

public class OrdersDetails
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public string EmployeeName { get; set; }
    public decimal freight { get; set; }
    public string ShipName { get; set; }
    public bool Verified { get; set; }
    public DateTime OrderDate { get; set; }

    public OrdersDetails(int orderId, string customerName, string employeeName, decimal freight, string shipName, bool verified, DateTime orderDate)
    {
        OrderId = orderId;
        CustomerName = customerName ?? throw new ArgumentNullException(nameof(customerName));
        EmployeeName = employeeName ?? throw new ArgumentNullException(nameof(employeeName));
        this.freight = freight;
        ShipName = shipName ?? throw new ArgumentNullException(nameof(shipName));
        Verified = verified;
        OrderDate = orderDate;
    }

    public static PagedData<OrdersDetails> GetOrderDetails()
    {
        QueryResult<PagedData<OrdersDetails>> order = new QueryResult<PagedData<OrdersDetails>>()
        {
            _data = new PagedData<OrdersDetails>()
            {
                PageNumber = 1,
                PageSize = 10,
                QueryResult = new List<OrdersDetails>()
                {
                new OrdersDetails(1, "ALFKI","emName 1", 1 + 0, "ShiPName 1", false, new DateTime(1991, 05, 15)),
                new OrdersDetails( 2, "ANATR", "emName 2", 2 + 2, "ShiPName 2", true, new DateTime(1990, 04, 04)),
                new OrdersDetails( 2, "ANATR", "emName 2", 2 + 2, "ShiPName 2", true, new DateTime(1990, 04, 04)),
                new OrdersDetails( 2, "ANATR", "emName 2", 2 + 2, "ShiPName 2", true, new DateTime(1990, 04, 04)),
                new OrdersDetails( 2, "ANATR", "emName 2", 2 + 2, "ShiPName 2", true, new DateTime(1990, 04, 04)),
                new OrdersDetails( 2, "ANATR", "emName 2", 2 + 2, "ShiPName 2", true, new DateTime(1990, 04, 04)),
                new OrdersDetails( 2, "ANATR", "emName 2", 2 + 2, "ShiPName 2", true, new DateTime(1990, 04, 04)),
                new OrdersDetails( 2, "ANATR", "emName 2", 2 + 2, "ShiPName 2", true, new DateTime(1990, 04, 04)),
                new OrdersDetails( 2, "ANATR", "emName 2", 2 + 2, "ShiPName 2", true, new DateTime(1990, 04, 04)),
                new OrdersDetails( 2, "ANATR", "emName 2", 2 + 2, "ShiPName 2", true, new DateTime(1990, 04, 04)),
                new OrdersDetails( 2, "ANATR", "emName 2", 2 + 2, "ShiPName 2", true, new DateTime(1990, 04, 04)),
                new OrdersDetails(3, "ANTON", "emName 3", 3 + 1, "ShiPName 3", true, new DateTime(1957, 11, 30)),
                new OrdersDetails(3, "ANTON", "emName 3", 3 + 1, "ShiPName 3", true, new DateTime(1957, 11, 30)),
                new OrdersDetails(3, "ANTON", "emName 3", 3 + 1, "ShiPName 3", true, new DateTime(1957, 11, 30)),
                new OrdersDetails(3, "ANTON", "emName 3", 3 + 1, "ShiPName 3", true, new DateTime(1957, 11, 30)),
                new OrdersDetails(3, "ANTON", "emName 3", 3 + 1, "ShiPName 3", true, new DateTime(1957, 11, 30)),
                new OrdersDetails(4, "BLONP", "emName 4", 4 + 3, "ShiPName 4", false, new DateTime(1930, 10, 22)),
                new OrdersDetails(4, "BLONP", "emName 4", 4 + 3, "ShiPName 4", false, new DateTime(1930, 10, 22)),
                new OrdersDetails(4, "BLONP", "emName 4", 4 + 3, "ShiPName 4", false, new DateTime(1930, 10, 22)),
                new OrdersDetails(4, "BLONP", "emName 4", 4 + 3, "ShiPName 4", false, new DateTime(1930, 10, 22)),
                new OrdersDetails(5, "BOLID", "emName 5", 5 + 4, "ShiPName 5", true, new DateTime(1953, 02, 18))
                }
            }
        };

        return order.Data;
    }
}
