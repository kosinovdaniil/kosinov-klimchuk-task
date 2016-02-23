using System.ComponentModel.DataAnnotations;

namespace Wunderlist.ViewModels
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Поле не может быть пустым!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}