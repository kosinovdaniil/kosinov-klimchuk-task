using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhotoPath { get; set; }

        public string Name { get; set; }

        public virtual IList<int> ListsId { get; set; }
    }
}