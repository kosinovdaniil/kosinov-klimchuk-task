using Epam.Wunderlist.DomainModel;
using System.Data.Entity.ModelConfiguration;

namespace Epam.Wunderlist.DataAccess.MssqlProvider.ModelsConfiguration
{
    public class ToDoListConfiguration : EntityTypeConfiguration<ToDoList>
    {
        public ToDoListConfiguration()
        {
            HasMany(x => x.Items).WithRequired(x => x.List);
        }
    }
}
