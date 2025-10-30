using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.Data.Configurations.OrganizationConfigurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> b)
        {
            b.ToTable("Organizations");

            b.HasKey(x => x.Id);

            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            b.Property(x => x.IsActive)
                .HasDefaultValue(true);

            // Relationship: Organization (1) -> (many) Companies
            b.HasMany(x => x.Companies)
             .WithOne(x => x.Organization)
             .HasForeignKey(x => x.OrganizationId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
