using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BllToDoList : IEntity
    {
        public int Id { get; set; }

        public virtual IList<BllToDoItem> Items { get; set; }

        public bool IsNotified { get; set; }

        public string Name { get; set; }

        public virtual IList<int> UsersId { get; set; }
    }
}
