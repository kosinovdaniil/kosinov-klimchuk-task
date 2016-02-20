using System;

namespace BLL.Interface.Entities
{
    public class BllFile : BllEntity
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public int BaseItemId { get; set; }

        public int UserId { get; set; }

        public DateTime AddingDate { get; set; }
    }
}
