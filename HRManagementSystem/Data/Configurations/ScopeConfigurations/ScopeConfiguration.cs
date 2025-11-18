using HRManagementSystem.Data.Models.Scopes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.Data.Configurations.ScopeConfigurations
{
    public class ScopeConfiguration : IEntityTypeConfiguration<Scope>
    {
        public void Configure(EntityTypeBuilder<Scope> builder)
        {
            builder.ToTable("Scopes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.OrganizationId)
                .IsRequired();

            builder.Property(x => x.CompanyId)
                .IsRequired();

            builder.Property(x => x.BranchId);
            builder.Property(x => x.DepartmentId);
            builder.Property(x => x.TeamId);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.HasIndex(x => new { x.CompanyId, x.OrganizationId, x.BranchId, x.DepartmentId, x.TeamId })
                .HasFilter("[OrganizationId] IS NOT NULL AND [BranchId] IS NOT NULL AND [DepartmentId] IS NOT NULL AND [TeamId] IS NOT NULL")
                .IsUnique();

            builder.HasMany(x => x.ShiftScopes)
                .WithOne(x => x.Scope)
                .HasForeignKey(x => x.ScopeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

