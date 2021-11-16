using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ECommerce.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var connectionString = ApplicationDbContext.DbConnectionString;
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new Exception("Missing connection string");
            }

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseNpgsql(
                connectionString
            );
            return new ApplicationDbContext(builder.Options);
        }
    }
}