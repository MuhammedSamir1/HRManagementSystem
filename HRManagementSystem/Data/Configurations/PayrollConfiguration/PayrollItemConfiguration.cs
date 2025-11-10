using HRManagementSystem.Data.Models.ConfigurationsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.Data.Configurations.PayrollConfiguration
{
    public class PayrollItemConfiguration : IEntityTypeConfiguration<PayrollItem>
    {
        public void Configure(EntityTypeBuilder<PayrollItem> b)
        {

            b.ToTable("PayrollItems");
            b.HasKey(x => x.Id);


            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            b.HasIndex(x => x.Name)
                .IsUnique();


            b.Property(x => x.Type)
                .HasConversion<string>()
                .IsRequired()
                .HasMaxLength(50);

            b.Property(x => x.CalculationType)
                .HasConversion<string>()
                .IsRequired()
                .HasMaxLength(50);


            b.Property(x => x.Value)
                .HasColumnType("decimal(18, 4)")
                .IsRequired();

            b.Property(x => x.IsStatutory)
                .IsRequired();



        }
    }
}
