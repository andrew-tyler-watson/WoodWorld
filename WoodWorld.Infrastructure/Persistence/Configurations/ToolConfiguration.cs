using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WoodWorld.Domain;

namespace WoodWorld.Infrastructure.Persistence.Configurations
{
    internal class ToolConfiguration : IEntityTypeConfiguration<Tool>
    {
        public void Configure(EntityTypeBuilder<Tool> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(t => t.Category)
                     .IsRequired()
                     .HasMaxLength(50);
            builder.Property(t => t.IsActive)
                     .IsRequired();
            builder.HasMany(t => t.Rentals)
                     .WithOne(r => r.Tool)
                     .HasForeignKey(r => r.ToolId);
            builder.ToTable("Tools");
        }
    }
}
