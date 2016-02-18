using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class File
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public virtual ToDoItem BaseItem { get; set; }

        public virtual int UserId { get; set; }

        public virtual DateTime AddingDate { get; set; }


    }
}
