using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.ClientMvc.Controllers
{
    [Route("{controller}/{action}")]
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Secret()
        {
            var jsonToken = await HttpContext.GetTokenAsync("access_token");
            var token = (JwtSecurityToken)new JwtSecurityTokenHandler().ReadToken(jsonToken);

            return View();
        }
    }
}
