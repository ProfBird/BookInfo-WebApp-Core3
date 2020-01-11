using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace GoodBookNook.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
