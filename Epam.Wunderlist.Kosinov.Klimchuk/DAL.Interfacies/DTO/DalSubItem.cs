using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalSubItem : IEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }
        
        public bool IsCompleted { get; set; }

        public int BaseItemId { get; set; }
    }
}
