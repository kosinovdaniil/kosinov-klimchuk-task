using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BllSubItem : IEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsCompleted { get; set; }

        public int BaseItemId { get; set; }
    }
}
