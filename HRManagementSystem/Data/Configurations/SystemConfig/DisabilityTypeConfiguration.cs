using HRManagementSystem.Data.Models.ConfigurationOfSys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.Data.Configurations.SystemConfig
{
    // Infrastructure/Data/Configurations/DisabilityTypeConfiguration.cs
    public class DisabilityTypeConfiguration : IEntityTypeConfiguration<DisabilityType>
    {
        public void Configure(EntityTypeBuilder<DisabilityType> builder)
        {
            builder.ToTable("DisabilityTypes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.Property(x => x.Code)
                .HasMaxLength(20);

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasIndex(x => x.Code)
                .IsUnique()
                .HasFilter("[Code] IS NOT NULL");

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
