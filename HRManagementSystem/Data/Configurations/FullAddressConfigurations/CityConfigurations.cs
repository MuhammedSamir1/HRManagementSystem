using HRManagementSystem.Data.Models.AddressEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.Data.Configurations.FullAddressConfigurations
{
    public class CityConfigurations : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();

            builder.HasOne(x => x.State)
             .WithMany(s => s.Cities)
             .HasForeignKey(x => x.StateId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.StateId, x.Name }).IsUnique();
        }
    }
}
