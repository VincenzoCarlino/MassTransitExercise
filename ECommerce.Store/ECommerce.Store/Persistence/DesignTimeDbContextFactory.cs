using System;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Store.Persistence
{
    public class DesignTimeDbContextFactory
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