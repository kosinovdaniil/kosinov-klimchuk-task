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
        public virtual DbSet<Goal> Goals { get; set; }
        public virtual DbSet<GoalList> GoalLists { get; set; }
        public virtual DbSet<GoalFolder> GoalFolders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GoalFolder>()
                .HasMany(e => e.GoalLists);
            modelBuilder.Entity<GoalList>()
                .HasMany(e => e.Goals);
            modelBuilder.Entity<User>()
                .HasMany(e => e.GoalLists);
        }
    }
}
