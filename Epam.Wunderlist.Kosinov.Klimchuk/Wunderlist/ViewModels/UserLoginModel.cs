using System.ComponentModel.DataAnnotations;

namespace Wunderlist.ViewModels
{
    public class UserLoginModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field can't be empty!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}