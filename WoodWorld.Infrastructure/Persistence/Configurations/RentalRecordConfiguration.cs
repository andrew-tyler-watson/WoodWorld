using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WoodWorld.Domain;

namespace WoodWorld.Infrastructure.Persistence.Configurations
{
    internal class RentalRecordConfiguration : IEntityTypeConfiguration<RentalRecord>
    {
        public void Configure(EntityTypeBuilder<RentalRecord> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.RentedAt).IsRequired();
            builder.Property(r => r.DueAt).IsRequired();
            builder.Property(r => r.ReturnedAt).IsRequired(false);
            builder.HasOne(r => r.User)
                   .WithMany(u => u.Rentals)
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(r => r.Tool)
                     .WithMany(t => t.Rentals)
                     .HasForeignKey(r => r.ToolId)
                     .OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("RentalRecords");
        }
    }
}
