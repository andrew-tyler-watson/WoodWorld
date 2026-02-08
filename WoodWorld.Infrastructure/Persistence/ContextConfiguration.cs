using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WoodWorld.Infrastructure.Persistence
{
    public static class ContextConfiguration
    {
        public static IServiceCollection AddWoodWorldContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString =
                configuration.GetConnectionString("DefaultConnection")
                    ?? throw new InvalidOperationException("Connection string"
                    + "'DefaultConnection' not found.");
            services.AddDbContext<WoodWorldContext>(options =>
                options.UseSqlite(connectionString));
            return services;
        }
    }
}
