using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class GoalFolder
    {
        public int Id { get; set; }

        public virtual IList<GoalList> GoalLists { get; set; }

        public string Name { get; set; }
    }
}
