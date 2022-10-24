using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using Syncfusion.EJ2.Linq;
using SyncfusionJavascript.Context;
using SyncfusionJavascript.Models;
using Zamin.Core.Contracts.ApplicationServices.Queries;

namespace SyncfusionJavascript.Controllers
{
    public class TestQr
    {

    }

    public enum StatusEnum
    {
        Active,
        InActive
    }
    public class SearchRequestQuery : PageQuery<TestQr>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public DateTime Birthdate { get; set; }
        public StatusEnum Status { get; set; }
    }

    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly SyncfusionDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, SyncfusionDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult SyncfusionData(
            [FromBody][ModelBinder(BinderType = typeof(CustomModelBinder))]
            SearchRequestQuery request)
        {
            var DataSource = dbContext.People.AsQueryable();
            DataOperations operation = new();
            var count = DataSource.Count();



            if (request.SkipCount != default)
                DataSource = operation.PerformSkip(DataSource, request.SkipCount);
            if (request.PageSize != default)
                DataSource = operation.PerformTake(DataSource, request.PageSize);

            if (request.SortBy != null)
            {
                DataSource = operation.PerformSorting(DataSource, new List<SortedColumn>() { new SortedColumn() { Field = request.SortBy } });
            }

            var json = Json(new { result = DataSource, count = count });
            return json;
        }




        public IActionResult SyncfusionTable()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
