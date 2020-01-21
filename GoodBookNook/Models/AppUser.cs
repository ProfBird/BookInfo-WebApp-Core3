using Microsoft.AspNetCore.Identity;

namespace GoodBookNook.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }  // Real name
    }
}
