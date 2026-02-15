using Microsoft.EntityFrameworkCore;
using WoodWorld.Domain;

namespace WoodWorld.Infrastructure.Persistence
{
    public class WoodWorldContext : DbContext
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
        public DbSet<Rental> Rentals { get; set; }
    }
}
