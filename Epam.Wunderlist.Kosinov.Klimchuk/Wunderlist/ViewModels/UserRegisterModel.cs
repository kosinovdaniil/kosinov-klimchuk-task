using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wunderlist.ViewModels
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "Put name")]
        [StringLength(20, ErrorMessage = "Should be less then 20 symbols")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Put email")]
        [StringLength(20, ErrorMessage = "Should be less then 20 symbols")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Put Password")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Password should 5 to 20 symbols")]
        [Compare("PasswordConfirm", ErrorMessage = "Passwords don't match")]
        public string Password { get; set; }

        public string PasswordConfirm { get; set; }

    }
}