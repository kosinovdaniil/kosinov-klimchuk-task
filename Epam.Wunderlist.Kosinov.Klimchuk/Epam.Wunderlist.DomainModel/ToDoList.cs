using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epam.Wunderlist.DomainModel
{
    public class ToDoList : Entity
    {
        public string Name { get; set; }

        public virtual IList<ToDoItem> Items { get; set; }

        public virtual IList<User> Users { get; set; }
    }
}
