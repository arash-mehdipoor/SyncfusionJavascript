using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SyncfusionJavascript.Context;
using SyncfusionJavascript.Models;
using System.Diagnostics;

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

        public JsonResult SyncfusionData()
        {
            var data = dbContext.OrderDetails.ToList().Take(10);

            return Json(new { data });
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