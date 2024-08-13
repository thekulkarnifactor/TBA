using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBA.Model;

namespace TBA.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Teams>
    {
        public void Configure(EntityTypeBuilder<Teams> builder)
        {
            builder.HasKey(t => t.TeamId);

            builder.Property(t => t.TeamId)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(t => t.TeamName)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            //builder.HasOne(t => t.Manager)
            //    .WithMany()
            //    .HasForeignKey(t => t.ManagerId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
