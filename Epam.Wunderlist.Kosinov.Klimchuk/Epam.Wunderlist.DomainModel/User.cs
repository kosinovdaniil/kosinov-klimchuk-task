using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Epam.Wunderlist.DomainModel
{
    public class User : Entity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string PhotoPath { get; set; }

        public string Name { get; set; }
         
        public IList<int> ListsId
        {
            get
            {
                return Lists.Select(x => x.Id).ToList();
            }
        }
        [JsonIgnore]
        public virtual IList<ToDoList> Lists { get; set; }
    }
}
