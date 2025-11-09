using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.Data.Configurations.ShiftConfigurations
{
    public class ShiftConfiguration : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> b)
        {
            b.ToTable("Shifts");

            b.HasKey(x => x.Id);

            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            b.HasIndex(x => x.Name)
                .IsUnique();

            b.Property(x => x.StartTime)
                .IsRequired();

            b.Property(x => x.EndTime)
                .IsRequired();

            b.Property(x => x.IsActive)
                .HasDefaultValue(true);

            b.Property(x => x.CreatedAt)
                .IsRequired();

            b.Property(x => x.UpdatedAt);
        }
    }
}

