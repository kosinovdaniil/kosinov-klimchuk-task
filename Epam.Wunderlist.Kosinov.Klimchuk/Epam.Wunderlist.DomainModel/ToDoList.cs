using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Epam.Wunderlist.DomainModel
{
    public class ToDoList : Entity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public virtual IList<int> ItemsId
        {
            get; set;
        }

        [JsonIgnore]
        public virtual IList<User> Users { get; set; }
    }
}
