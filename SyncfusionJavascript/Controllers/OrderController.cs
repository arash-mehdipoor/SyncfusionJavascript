using Microsoft.AspNetCore.Mvc;
using SyncfusionJavascriptSample.Models;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;

namespace SyncfusionJavascriptSample.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{

    [HttpGet]
    public PagedData<OrdersDetails> GetOrderList()
    {
        //PagedData<OrdersDetails> q = OrdersDetails.GetOrderDetails();
        QueryResult<PagedData<OrdersDetails>> queryResult = new QueryResult<PagedData<OrdersDetails>>();
        queryResult._data = OrdersDetails.GetOrderDetails();


        return queryResult.Data;
    }
}
