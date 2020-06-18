using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKontakte.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace VKontakte.Data
{
    public static class DatabaseInitializer
    {
        public static void Init(IServiceProvider scopeServiceProvider)
        {
            var userManager = scopeServiceProvider.GetService<UserManager<ApplicationUser>>();
            var context = scopeServiceProvider.GetService<ApplicationDbContext>();
            context.Database.EnsureDeleted();

            var user = new ApplicationUser
            {
                UserName = "admin",
                LastName = "Smith",
                FirstName = "John"
            };

            var result = userManager.CreateAsync(user, "123qwe").GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Administrator"));
            }
        }
    }
}
