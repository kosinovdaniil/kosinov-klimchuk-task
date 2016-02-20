using System;
using System.Collections.Generic;

namespace ORM
{
    public class ToDoItem : Entity
    {
        public string Text { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsFavourited { get; set; }

        public DateTime AddingDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public string Note { get; set; }

        public IList<SubItem> SubItems { get; set; }

        public IList<File> Files { get; set; }

        public virtual ToDoList List { get; set; }
    }
}
