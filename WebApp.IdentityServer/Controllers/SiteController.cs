using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.IdentityServer.Controllers
{
    [Route("{controller}/{action}")]
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Secret()
        {
            return "Secret string from Orders API";
        }
    }
}
