using DAL.Interfacies.DTO;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalUser : DalEntity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string PhotoPath { get; set; }

        public string Name { get; set; }

        public IList<int> ListsId { get; set; }
    }
}