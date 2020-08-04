using Microsoft.EntityFrameworkCore;
using TaskHandler.Data.Models;

namespace TaskHandler.Data
{
    public class TaskContext : DbContext
    {
        public DbSet<TaskData> Tasks { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskData>()
                .HasKey(t => t.TaskID);

            modelBuilder.Entity<TaskData>()
                .Property(d => d.Description).IsRequired();

            modelBuilder.Entity<TaskData>()
                .Property(t => t.CreateTime).HasDefaultValueSql("getutcdate()");

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=TasksDB;Trusted_Connection=True;");
        }
    }
}