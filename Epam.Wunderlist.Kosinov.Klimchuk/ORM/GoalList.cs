using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class GoalList
    {
        public int Id { get; set; }

        public virtual IList<Goal> Goals { get; set; }

        public bool IsNotified { get; set; }

        public string Name { get; set; }
    }
}
