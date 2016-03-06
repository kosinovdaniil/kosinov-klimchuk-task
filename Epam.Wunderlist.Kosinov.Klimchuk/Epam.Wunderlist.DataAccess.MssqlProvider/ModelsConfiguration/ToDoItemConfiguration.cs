using Epam.Wunderlist.DomainModel;
using System.Data.Entity.ModelConfiguration;

namespace Epam.Wunderlist.DataAccess.MssqlProvider.ModelsConfiguration
{
    public class ToDoItemConfiguration : EntityTypeConfiguration<ToDoItem>
    {
        public ToDoItemConfiguration()
        {
        }
    }
}
