using System.Collections.Generic;

namespace ORM
{
    public class ToDoList : Entity
    {
        public virtual IList<ToDoItem> Items { get; set; }

        public string Name { get; set; }

        public virtual IList<User> Users { get; set; }
    }
}
