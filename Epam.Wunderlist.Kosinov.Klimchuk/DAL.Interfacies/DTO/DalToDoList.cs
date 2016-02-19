using DAL.Interfacies.DTO;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalToDoList : DalEntity
    {
        public virtual IList<int> ItemsId { get; set; }

        public string Name { get; set; }

        public virtual IList<int> UsersId { get; set; }
    }
}
