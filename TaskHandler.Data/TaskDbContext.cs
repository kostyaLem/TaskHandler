using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using TaskHandler.Data.Migrations;
using TaskHandler.Data.Models;

namespace TaskHandler.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext()
            : base(@"data source=.\sqlexpress;initial catalog=TasksDb;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TaskDbContext, Configuration>());
        }

        public virtual DbSet<TaskData> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskData>()
               .HasKey(t => t.TaskID);

            modelBuilder.Entity<TaskData>()
                .Property(d => d.Description).IsRequired();

            modelBuilder.Entity<TaskData>()
                .Property(t => t.CreateTime)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            base.OnModelCreating(modelBuilder);
        }
    }
}
