using DAL.Interfacies.DTO;

namespace DAL.Interface.DTO
{
    public class DalSubItem : DalEntity
    {
        public string Text { get; set; }
        
        public bool IsCompleted { get; set; }

        public int BaseItemId { get; set; }
    }
}
