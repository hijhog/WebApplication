using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VKontakte.Models
{
    public class ExternalLoginViewModel
    {
        public string UserName { get; set; }

        public string ReturnUrl { get; set; }
    }
}
