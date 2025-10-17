using HRManagementSystem.Data.Models.AddressEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.Data.Configurations.FullAddressConfigurations
{
    public class CountryConfigurations : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Iso2).HasMaxLength(2).IsRequired();
            builder.Property(x => x.Iso3).HasMaxLength(3).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(x => x.Iso2).IsUnique();
            builder.HasIndex(x => x.Iso3).IsUnique();
            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
