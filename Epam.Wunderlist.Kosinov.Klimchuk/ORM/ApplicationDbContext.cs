using System.Data.Entity;

namespace ORM
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=GoalsDatabase")
        {
        }
        
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ToDoItem> Items { get; set; }
        public virtual DbSet<ToDoList> Lists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Lists)
                .WithMany(e => e.Users);

            modelBuilder.Entity<ToDoList>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.List);
        }

        public void Dispose()
        {
            base.Dispose();
        }
    }
}
