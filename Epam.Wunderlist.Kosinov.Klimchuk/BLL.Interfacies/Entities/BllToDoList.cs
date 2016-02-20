using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class BllToDoList : BllEntity
    {
        public virtual IList<int> ItemsId { get; set; }

        public string Name { get; set; }

        public virtual IList<int> UsersId { get; set; }
    }
}
