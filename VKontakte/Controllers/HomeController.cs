using Microsoft.AspNetCore.Mvc;

namespace VKontakte.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}