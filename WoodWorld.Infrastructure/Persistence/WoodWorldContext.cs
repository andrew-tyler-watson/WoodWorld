using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WoodWorld.Domain;

namespace WoodWorld.Infrastructure.Persistence
{
    internal class WoodWorldContext : DbContext
    {
        public WoodWorldContext(DbContextOptions<WoodWorldContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WoodWorldContext).Assembly);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<RentalRecord> RentalRecords { get; set; }
    }
}
