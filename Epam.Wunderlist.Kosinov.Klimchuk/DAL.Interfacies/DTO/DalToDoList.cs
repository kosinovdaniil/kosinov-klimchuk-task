using DAL.Interfacies.DTO;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalToDoList : DalEntity
    {
        public IList<int> ItemsId { get; set; }

        public bool IsNotified { get; set; }

        public string Name { get; set; }

        public IList<int> UsersId { get; set; }
    }
}
