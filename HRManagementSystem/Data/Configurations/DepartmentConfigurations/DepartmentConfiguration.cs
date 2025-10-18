using HRManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.Data.Configurations.DepartmentConfigurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> b)
        {
            b.ToTable("Departments");

            b.HasKey(x => x.Id);

            b.Property(x => x.BranchId)
                .IsRequired();

            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            b.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(50);

            // كود القسم فريد داخل نفس الفرع
            b.HasIndex(x => new { x.BranchId, x.Code })
                .IsUnique();

            b.Property(x => x.Description)
                .HasMaxLength(500);

            b.Property(x => x.IsActive)
                .HasDefaultValue(true);

            b.Property(x => x.CreatedAt)
                .IsRequired();

            b.Property(x => x.UpdatedAt);

            // العلاقة: Branch (1) ← Department (many)
            b.HasOne(x => x.Branch)
             .WithMany(br => br.Departments)
             .HasForeignKey(x => x.BranchId)
             .OnDelete(DeleteBehavior.Restrict);

            // العلاقة: Department (1) → Team (many)
            b.HasMany(x => x.Teams)
             .WithOne(t => t.Department)
             .HasForeignKey(t => t.DepartmentId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
