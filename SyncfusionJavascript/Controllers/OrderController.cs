using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using Syncfusion.EJ2.Linq;
using SyncfusionJavascript.Context;
using SyncfusionJavascript.Models;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;

namespace SyncfusionJavascriptSample.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly SyncfusionDbContext _dbContext;

    public OrderController(SyncfusionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public PagedData<OrdersDetails> GetOrderList()
    {
        //PagedData<OrdersDetails> q = OrdersDetails.GetOrderDetails();
        QueryResult<PagedData<OrdersDetails>> queryResult = new QueryResult<PagedData<OrdersDetails>>();
        queryResult._data = OrdersDetails.GetOrderDetails();


        return queryResult.Data;
    }

    public IActionResult SyncfusionData(
            [FromBody][ModelBinder(BinderType = typeof(CustomModelBinder))]
            PageQuery<OrdersDetails> request)
    {
        var DataSource = _dbContext.People.AsQueryable();
        DataOperations operation = new();
        var count = DataSource.Count();

        return new JsonResult(new { result = DataSource, count = count });
    }
}
