namespace ORM
{
    using System.Data.Entity;

    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=GoalsDatabase")
        {
        }
        
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ToDoItem> Items { get; set; }
        public virtual DbSet<ToDoList> Lists { get; set; }
        public virtual DbSet<SubItem> SubItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Lists)
                .WithMany(e => e.Users);
            modelBuilder.Entity<ToDoList>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.List);
            modelBuilder.Entity<ToDoItem>()
                .HasMany(e => e.SubItems)
                .WithRequired(e => e.BaseItem);
            modelBuilder.Entity<ToDoItem>()
                .HasMany(e => e.Files)
                .WithRequired(e => e.BaseItem);
        }
    }
}
