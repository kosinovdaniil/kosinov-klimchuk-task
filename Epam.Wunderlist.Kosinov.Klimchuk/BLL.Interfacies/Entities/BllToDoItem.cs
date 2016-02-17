using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BllToDoItem : IEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsFavourited { get; set; }

        public DateTime AddingDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public string Note { get; set; }

        public IList<BllSubItem> SubItems { get; set; }

        public IList<BllFile> Files { get; set; }

        public virtual int ListId { get; set; }
    }
}
