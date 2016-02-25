using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORM
{
    public partial class User : Entity
    {
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string Password { get; set; }

        public string PhotoPath { get; set; }

        public string Name { get; set; }

        public virtual IList<ToDoList> Lists { get; set; }
    }
}
