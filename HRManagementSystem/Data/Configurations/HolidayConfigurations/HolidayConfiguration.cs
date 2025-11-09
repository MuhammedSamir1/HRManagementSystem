using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HRManagementSystem.Data.Models.ConfigurationsModels;

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

         
            b.HasIndex(x => new { x.Name, x.CompanyId }).IsUnique();

            b.Property(x => x.CreatedAt).IsRequired();

            //  Company (1) ← Holiday (many)
            b.HasOne(x => x.Company)
                .WithMany()
                .HasForeignKey(x => x.CompanyId)
                
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
