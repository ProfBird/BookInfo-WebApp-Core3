

using System.ComponentModel.DataAnnotations;

namespace GoodBookNook.Models
{
    public class LoginViewModel
    {
        [Required]
        [UIHint("EmailAddress")]    // sets <Input type="email" ... />
        public string Email { get; set; }
        [Required]
        [UIHint("Password")]   // sets <Input type="password" ... />
        public string Password { get; set; }
    }

}


// UIHint will set HTML INPUT type attributes in views with forms.