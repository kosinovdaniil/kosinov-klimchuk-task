using Epam.Wunderlist.DomainModel;
using System.Data.Entity;
using Epam.Wunderlist.DataAccess.MssqlProvider.ModelsConfiguration;

namespace Epam.Wunderlist.DataAccess.MssqlProvider
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=GoalsDatabase")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationDbContext>());
        }
        
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ToDoItem> Items { get; set; }
        public virtual DbSet<ToDoList> Lists { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ToDoListConfiguration());
            modelBuilder.Configurations.Add(new ToDoItemConfiguration());
        }

        public void Dispose()
        {
            base.Dispose();
        }
    }
}
