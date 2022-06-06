using Microsoft.EntityFrameworkCore;

using Master.Models.EntityModels;
using Master.Utilities;
using Microsoft.Data.SqlClient;
using System.Linq;

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

        //public virtual int ExecuteSqlRaw(string sql)
        //{
        //    return Database.ExecuteSqlRaw(sql);
        //}  
        //public virtual int ExecuteSqlRaw(string sql, SqlParameter[] parameters)
        //{
        //    return Database.ExecuteSqlRaw(sql, parameters);
        //}
        public virtual IQueryable<TEntity> RunFromSqlRaw<TEntity>(string sql) where TEntity : class
        {
            return this.Set<TEntity>().FromSqlRaw(sql);
        } 
        public virtual IQueryable<TEntity> RunFromSqlRaw<TEntity>(string sql, SqlParameter[] parameters) where TEntity : class
        {
            return this.Set<TEntity>().FromSqlRaw(sql, parameters);
        }  

    }
}
