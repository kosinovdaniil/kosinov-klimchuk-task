using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class BllToDoList : BllEntity
    {
        public IList<int> ItemsId { get; set; }

        public string Name { get; set; }

        public IList<int> UsersId { get; set; }
    }
}
