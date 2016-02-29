using Epam.Wunderlist.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Wunderlist.DataAccess.MssqlProvider.ModelsConfiguration
{
    public class ToDoItemConfiguration : EntityTypeConfiguration<ToDoItem>
    {
        public ToDoItemConfiguration()
        {
            HasRequired(x => x.List).WithMany(x => x.Items);
            HasMany(x => x.Users);
        }
    }
}
