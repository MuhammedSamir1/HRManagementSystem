using HRManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.Data.Configurations.CompanyConfigurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> b)
        {
            b.ToTable("Companies");

            b.HasKey(x => x.Id);

            b.Property(x => x.OrganizationId)
                .IsRequired();

            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            b.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(50);

            b.HasIndex(x => new { x.OrganizationId, x.Code })
                .IsUnique();

            b.Property(x => x.IsActive)
                .HasDefaultValue(true);

            b.Property(x => x.CreatedAt)
                .IsRequired();

            b.Property(x => x.UpdatedAt);

            // Concurrency token
            b.Property(x => x.RowVersion)
                .IsRowVersion();

            // العلاقة: Organization (1) ← Company (many)
            b.HasOne(x => x.Organization)
             .WithMany(o => o.Companies)
             .HasForeignKey(x => x.OrganizationId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
