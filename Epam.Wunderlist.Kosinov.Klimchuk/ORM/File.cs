using System;

namespace ORM
{
    public class File : Entity
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public virtual ToDoItem BaseItem { get; set; }

        public virtual int UserId { get; set; }

        public virtual DateTime AddingDate { get; set; }


    }
}
