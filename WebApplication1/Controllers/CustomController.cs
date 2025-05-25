using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ArgumentOutOfRangeExceptionFilter]
    public class CustomController : Controller
    {
        [CustomAuthorize]
        public IActionResult Execute(string action, int? id)
        {
            if (action == "start" && (id ?? 0) == 0)
            {
                // Перенаправление на Index обычного контроллера
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var url = $"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}";
                return Content($"Ошибка: неверные параметры.\nURL: {url}", "text/plain");
            }
        }
    }
} 