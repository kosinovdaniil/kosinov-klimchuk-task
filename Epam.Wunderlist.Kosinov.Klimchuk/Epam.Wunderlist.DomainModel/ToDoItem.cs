﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epam.Wunderlist.DomainModel
{
    public class ToDoItem : Entity
    {

        public string Text { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsFavourited { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime? DateCompletion { get; set; }

        public string Note { get; set; }

        public virtual ToDoList List { get; set; }

        public virtual IList<User> Users { get; set; }
    }
}