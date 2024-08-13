using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBA.Model;

namespace TBA.Configurations
{
    public class TaskNoteConfiguration : IEntityTypeConfiguration<TaskNotes>
    {
        public void Configure(EntityTypeBuilder<TaskNotes> builder)
        {
            builder.HasKey(tn => tn.NoteId);

            builder.Property(tn => tn.NoteId)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(tn => tn.Content)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(tn => tn.CreatedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            //builder.HasOne(tn => tn.Task)
            //    .WithMany(t => t.Notes)
            //    .HasForeignKey(tn => tn.TaskId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(tn => tn.Creator)
            //    .WithMany()
            //    .HasForeignKey(tn => tn.CreatedBy)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
