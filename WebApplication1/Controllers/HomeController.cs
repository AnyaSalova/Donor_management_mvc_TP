using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ArgumentOutOfRangeExceptionFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [CustomAuthorize]
        [HttpPost]
        public IActionResult Index(int? id, string name, int? age, string bloodGroup, string phone, bool recall)
        {
            if (id.HasValue)
            {
                ViewBag.Id = id;
                ViewBag.Name = name;
                ViewBag.Age = age;
                ViewBag.BloodGroup = bloodGroup;
                ViewBag.Phone = phone;
                ViewBag.Recall = recall;
                return View("Result");
            }
            else
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
