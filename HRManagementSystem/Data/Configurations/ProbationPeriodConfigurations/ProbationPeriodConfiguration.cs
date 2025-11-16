using HRManagementSystem.Data.Models.ConfigurationsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.Data.Configurations.ProbationPeriodConfigurations
{
    public class ProbationPeriodConfiguration : IEntityTypeConfiguration<ProbationPeriod>
    {
        public void Configure(EntityTypeBuilder<ProbationPeriod> b)
        {
            b.ToTable("ProbationPeriods");

            b.HasKey(x => x.Id);

            b.Property(x => x.StartDate)
                .IsRequired();

            b.Property(x => x.EndDate)
                .IsRequired();

            b.Property(x => x.DurationInDays)
                .IsRequired();

            b.Property(x => x.IsApproved)
                .IsRequired()
                .HasDefaultValue(false);

            b.Property(x => x.ApprovalDate);

            b.Property(x => x.Status)
                .IsRequired()
                .HasConversion<int>();

            b.Property(x => x.IsActive)
                .HasDefaultValue(true);

            b.Property(x => x.CreatedAt)
                .IsRequired();

            b.Property(x => x.UpdatedAt);
        }
    }
}


