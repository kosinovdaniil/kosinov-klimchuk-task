namespace ORM
{
    public class SubItem : Entity
    {
        public string Text { get; set; }
        
        public bool IsCompleted { get; set; }

        public ToDoItem BaseItem { get; set; }
    }
}
