using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagementSystem.Data.Configurations.UserConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // اسم الجدول
            builder.ToTable("Users");

            // الخصائص الأساسية
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(200);

            //// العلاقة مع Role (لو Role كيان منفصل)
            //builder.HasOne(u => u.Role)
            //    .WithMany() // أو WithMany(r => r.Users) لو فيه ICollection<User> في Role
            //    .HasForeignKey("RoleId") // لو بتستخدم RoleId كـ FK
            //    .IsRequired();
        }
    }
}
