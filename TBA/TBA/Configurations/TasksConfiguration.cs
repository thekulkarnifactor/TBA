using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBA.Model;

namespace TBA.Configurations
{
    public class TasksConfiguration : IEntityTypeConfiguration<Tasks>
    {
        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
            builder.HasKey(t => t.TaskId);

            builder.Property(t => t.TaskId)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(t => t.Title)
                .HasColumnType("nvarchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.Status)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.DueDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(t => t.CreatedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            //builder.HasOne(t => t.Creator)
            //    .WithMany(e => e.TasksCreated)
            //    .HasForeignKey(t => t.CreatedBy)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne(t => t.Assignee)
            //    .WithMany(e => e.TasksAssigned)
            //    .HasForeignKey(t => t.AssignedTo)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
