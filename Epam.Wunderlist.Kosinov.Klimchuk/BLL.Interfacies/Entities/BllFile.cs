using System;

namespace BLL.Interface.Entities
{
    public class BllFile : BllEntity
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public virtual int BaseItemId { get; set; }

        public virtual int UserId { get; set; }

        public virtual DateTime AddingDate { get; set; }
    }
}
