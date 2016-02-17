using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BllFile : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public virtual int BaseItemId { get; set; }

        public virtual int UserId { get; set; }

        public virtual DateTime AddingDate { get; set; }


    }
}
