using HRManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.Data.Configurations.TeamConfigurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> b)
        {
            b.ToTable("Teams");

            b.HasKey(x => x.Id);

            b.Property(x => x.DepartmentId)
                .IsRequired();

            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            b.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(50);

            // كود الفريق فريد داخل نفس القسم
            b.HasIndex(x => new { x.DepartmentId, x.Code })
                .IsUnique();

            b.Property(x => x.Description)
                .HasMaxLength(500);

            b.Property(x => x.IsActive)
                .HasDefaultValue(true);

            b.Property(x => x.CreatedAt)
                .IsRequired();

            b.Property(x => x.UpdatedAt);

            // Concurrency token
            b.Property(x => x.RowVersion)
                .IsRowVersion();

            // العلاقة: Department (1) ← Team (many)
            b.HasOne(x => x.Department)
             .WithMany(d => d.Teams)
             .HasForeignKey(x => x.DepartmentId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
