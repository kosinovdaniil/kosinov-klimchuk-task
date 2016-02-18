﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class ToDoList
    {
        public int Id { get; set; }

        public virtual IList<ToDoItem> Items { get; set; }

        public bool IsNotified { get; set; }

        public string Name { get; set; }

        public virtual IList<User> Users { get; set; }
    }
}
