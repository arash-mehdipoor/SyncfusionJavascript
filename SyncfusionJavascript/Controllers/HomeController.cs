using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using SyncfusionJavascript.Context;
using SyncfusionJavascript.Models;

namespace SyncfusionJavascript.Controllers
{

    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly SyncfusionDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, SyncfusionDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult SeedData()
        {

            List<OrderDetail> ordersDetails = new List<OrderDetail>();

            if (ordersDetails.Count() == 0)
            {
                int code = 100;
                for (int i = 1; i < 100; i++)
                {
                    ordersDetails.Add(new OrderDetail()
                    {
                        FirstName = $"آرش {i}",
                        LastName = $"مهدی پور {i}",
                        Address = $"تهران,تهران {i}",
                        Age = 29,
                        Birthdate = DateTime.Now,
                        City = "تهران",
                        Status = i % code == 0 ? true : false,
                    });
                    code += 5;
                }
            }
            dbContext.OrderDetails.AddRange(ordersDetails);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(SyncfusionTable));
        }

        public IActionResult SyncfusionData([FromBody] DataManagerRequest request)
        {
            var query = dbContext.OrderDetails;
            var data = query.ToList();

            if (request.Search is not null)
            {
                data = data.Where(x => x.FirstName.Contains(request.Search[0].Key)).ToList();
            }

            var count = data.Count();
            data = data.Skip(request.Skip).Take(request.Take).ToList();
            var json = Json(new { result = data, count = count });
            return json;
        }




        public IActionResult SyncfusionTable()
        {
            var data = dbContext.OrderDetails.ToList();
            return View(data);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}