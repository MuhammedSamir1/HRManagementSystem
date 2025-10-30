using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.Data.Configurations.BranchConfigurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> b)
        {
            b.ToTable("Branches");

            b.HasKey(x => x.Id);

            b.Property(x => x.CompanyId)
                .IsRequired();

            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            b.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(50);

            // كود الفرع فريد داخل نفس الشركة
            b.HasIndex(x => new { x.CompanyId, x.Code })
                .IsUnique();

            b.Property(x => x.IsActive)
                .HasDefaultValue(true);


            b.Property(x => x.CreatedAt)
                .IsRequired();

            b.Property(x => x.UpdatedAt);

            // العلاقة: Company (1) ← Branch (many)
            b.HasOne(x => x.Company)
             .WithMany(c => c.Branches)
             .HasForeignKey(x => x.CompanyId)
             .OnDelete(DeleteBehavior.Restrict);

            // العلاقة: Branch (1) → Department (many)
            b.HasMany(x => x.Departments)
             .WithOne(d => d.Branch)
             .HasForeignKey(d => d.BranchId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
