using Microsoft.AspNetCore.Identity;
using System;

namespace VKontakte.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {

        }
        public ApplicationUser(string userName): base(userName)
        {

        }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
