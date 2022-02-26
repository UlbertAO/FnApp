using Microsoft.EntityFrameworkCore;

using Master.Models.EntityModels;
using Master.Utilities;

namespace Master.EntityFramework
{
    public class MyDbContext : DbContext
    {
        public static string connectionString;

        public MyDbContext()
        {
            connectionString = EnvironmentSettings.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (connectionString == null)
                {
                    connectionString = "(localdb)\\MSSQLLocalDB";
                }
                optionsBuilder.UseSqlServer(connectionString);
                base.OnConfiguring(optionsBuilder);
            }
        }
        public virtual DbSet<CustomerDetails> CustomerDetails { get; set; }
    }
}
