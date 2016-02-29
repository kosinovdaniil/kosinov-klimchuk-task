using Epam.Wunderlist.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Wunderlist.DataAccess.MssqlProvider.ModelsConfiguration
{
    public class ToDoListConfiguration : EntityTypeConfiguration<ToDoList>
    {
        public ToDoListConfiguration()
        {
        }
    }
}
