using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.OrdersApi.Controllers
{
    [Route("{controller}/{action}")]
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public string Secret()
        {
            return "Secret string from Orders API";
        }
    }
}
