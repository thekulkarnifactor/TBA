using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBA.Model;

namespace TBA.Configurations
{
    public class TaskAttachmentConfiguration : IEntityTypeConfiguration<TaskAttachment>
    {
        public void Configure(EntityTypeBuilder<TaskAttachment> builder)
        {
            builder.HasKey(ta => ta.AttachmentId);

            builder.Property(ta => ta.AttachmentId)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(ta => ta.FilePath)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(ta => ta.UploadedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            //// Defining the relationship between TaskAttachment and Task
            //builder.HasOne(ta => ta.Task)
            //    .WithMany(t => t.Attachments)
            //    .HasForeignKey(ta => ta.TaskId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //// Defining the relationship between TaskAttachment and the uploader (presumably an Employee)
            //builder.HasOne(ta => ta.Uploader)
            //    .WithMany()
            //    .HasForeignKey(ta => ta.UploadedBy)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
