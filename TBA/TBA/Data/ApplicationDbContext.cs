using Microsoft.EntityFrameworkCore;
using TBA.Configurations;
using TBA.Model;

namespace TBA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TaskNotes> TaskNotes { get; set; }
        public DbSet<TaskAttachment> TaskAttachments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply the configurations for the entities
            modelBuilder.ApplyConfiguration(new TaskAttachmentConfiguration());
            modelBuilder.ApplyConfiguration(new TaskNoteConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new TasksConfiguration());


        }
    }
}
