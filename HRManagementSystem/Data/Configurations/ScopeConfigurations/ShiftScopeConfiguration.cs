using HRManagementSystem.Data.Models.Scopes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.Data.Configurations.ScopeConfigurations
{
    public class ShiftScopeConfiguration : IEntityTypeConfiguration<ShiftScope>
    {
        public void Configure(EntityTypeBuilder<ShiftScope> builder)
        {
            builder.ToTable("ShiftScopes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ScopeId)
                .IsRequired();

            builder.Property(x => x.ShiftId)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.HasIndex(x => new { x.ShiftId, x.ScopeId })
                .IsUnique();

            builder.HasOne(x => x.Scope)
                .WithMany(x => x.ShiftScopes)
                .HasForeignKey(x => x.ScopeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Shift)
                .WithMany()
                .HasForeignKey(x => x.ShiftId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

