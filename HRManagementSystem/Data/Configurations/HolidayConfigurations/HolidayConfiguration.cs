using HRManagementSystem.Data.Models.ConfigurationsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.Data.Configurations.HolidayConfigurations
{
    public class HolidayConfiguration : IEntityTypeConfiguration<Holiday>
    {
        public void Configure(EntityTypeBuilder<Holiday> b)
        {
            b.ToTable("Holidays");

            b.HasKey(x => x.Id);

            b.Property(x => x.Name).IsRequired().HasMaxLength(150);
            b.Property(x => x.StartDate).IsRequired();
            b.Property(x => x.EndDate).IsRequired();


            b.Property(x => x.IsMandatory).HasDefaultValue(true).IsRequired();
            b.Property(x => x.Type).IsRequired();

            b.HasIndex(x => x.Name).IsUnique();

            b.Property(x => x.CreatedAt).IsRequired();
        }
    }
}
