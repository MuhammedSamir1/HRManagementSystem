using HRManagementSystem.Data.Models.AddressEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.Data.Configurations.FullAddressConfigurations
{
    public class StateConfigurations : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.HasOne(x => x.Country)
             .WithMany(c => c.States)
             .HasForeignKey(x => x.CountryId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.CountryId, x.Name }).IsUnique();
            builder.HasIndex(x => new { x.CountryId, x.Code }).IsUnique();
        }
    }
}
