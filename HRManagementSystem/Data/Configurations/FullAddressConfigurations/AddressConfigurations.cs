using HRManagementSystem.Data.Models.AddressEntity;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Data.Configurations.FullAddressConfigurations
{
    public class AddressConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Country)
             .WithMany()
             .HasForeignKey(x => x.CountryId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.State)
             .WithMany()
             .HasForeignKey(x => x.StateId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.City)
             .WithMany()
             .HasForeignKey(x => x.CityId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
