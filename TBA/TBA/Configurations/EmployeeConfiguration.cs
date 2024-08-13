using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBA.Model;

namespace TBA.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.EmployeeId);

            builder.Property(e => e.EmployeeId)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Role)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            //builder.HasOne(e => e.Manager)
            //    .WithMany(m => m.Subordinates)
            //    .HasForeignKey(e => e.ManagerId)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(e => e.Email).IsUnique();
        }
    }
}
