using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ORM
{
    public partial class User
    {
        /*public User()
        {
            Publications = new List<Content>();
            VotedPublications = new List<Content>();
            Comments = new List<Comment>();
            Roles = new List<Role>();
        }*/
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(10)]
        public string Password { get; set; }

        public string PhotoPath { get; set; }

        public string Name { get; set; }
    }
}
