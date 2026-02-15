using Microsoft.EntityFrameworkCore;
using WoodWorld.Domain;

namespace WoodWorld.Infrastructure.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(u => u.CreatedAt)
                .IsRequired();
            builder.Property(u => u.IsActive)
                .IsRequired();
            builder.HasMany(u => u.Rentals)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);
            builder.ToTable("Users");
        }
    }
}
