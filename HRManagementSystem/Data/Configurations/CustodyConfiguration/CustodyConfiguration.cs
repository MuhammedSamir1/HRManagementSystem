using HRManagementSystem.Data.Models.ConfigurationsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.Data.Configurations.CustodyConfiguration
{
    // يجب تطبيق IEntityTypeConfiguration على كيان Custody
    public class CustodyConfiguration : IEntityTypeConfiguration<Custody>
    {
        public void Configure(EntityTypeBuilder<Custody> b)
        {
            // 1. اسم الجدول والمفتاح الأساسي
            b.ToTable("Custodies");

            b.HasKey(x => x.Id);

            // 2. خصائص العهدة
            b.Property(x => x.ItemName).IsRequired().HasMaxLength(250);
            b.Property(x => x.SerialNumber).IsRequired().HasMaxLength(150);

            b.Property(x => x.HandoverDate).IsRequired();

            b.Property(x => x.ReturnDate).IsRequired(false);

            b.Property(x => x.Status).IsRequired().HasMaxLength(50);

            b.HasIndex(x => x.SerialNumber).IsUnique();

            b.Property(x => x.CreatedAt).IsRequired();

        }
    }
}
