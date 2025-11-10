using HRManagementSystem.Data.Models.ConfigurationsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.Data.Configurations.OvertimeConfiguration
{
    public class OvertimeRateConfiguration : IEntityTypeConfiguration<OvertimeRate>
    {
        public void Configure(EntityTypeBuilder<OvertimeRate> b)
        {

            b.ToTable("OvertimeRates");
            b.HasKey(x => x.Id);


            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);


            b.Property(x => x.Multiplier)
                .HasColumnType("decimal(5, 2)")
                .IsRequired();


            b.Property(x => x.DayType)
                .HasConversion<string>()
                .IsRequired()
                .HasMaxLength(50);


            b.HasIndex(x => x.DayType)
                .IsUnique();


        }
    }
}
