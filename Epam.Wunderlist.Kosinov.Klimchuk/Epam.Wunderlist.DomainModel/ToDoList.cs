using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Epam.Wunderlist.DomainModel
{
    public class ToDoList : Entity
    {
        public string Name { get; set; }

        public virtual IList<int> ItemsId
        {
            get; set;
        }
       
        public IList<int> UsersId
        {
            get
            {
                return Users.Select(x => x.Id).ToList();
            }
        }

        public virtual IList<User> Users { get; set; }
    }
}
