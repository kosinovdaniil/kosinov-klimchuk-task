namespace BLL.Interface.Entities
{
    public class BllSubItem : BllEntity
    {
        public string Text { get; set; }

        public bool IsCompleted { get; set; }

        public int BaseItemId { get; set; }
    }
}
