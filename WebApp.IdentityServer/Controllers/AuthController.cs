using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.IdentityServer.Models;

namespace WebApp.IdentityServer.Controllers
{
    [Route("[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AuthController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);
            if(user == null)
            {
                ModelState.AddModelError("", "User not found");
                return View(model);
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (signInResult.Succeeded)
            {
                return Redirect(model.ReturnUrl);
            }

            ModelState.AddModelError("", "Something went wrong");
            return View(model);
        }
    }
}
