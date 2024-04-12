using System.Configuration;
using System.Windows;
using Microsoft.EntityFrameworkCore;


namespace Expertsystem.Services.DBConnection
{
    public partial class PostgresSQL : DbContext
    {
        public PostgresSQL()
        {
        }

        public PostgresSQL(DbContextOptions<PostgresSQL> options)
            : base(options)
        {
        }

  

        // Retrieves a connection string by name.
        // Returns null if the name is not found.
        static string? GetConnectionStringByName(string name)
        {
            // Look for the name in the connectionStrings section.
            ConnectionStringSettings? settings =
                ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string (otherwise return null)
            //MessageBox.Show(settings?.ConnectionString);
            return settings?.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

            => optionsBuilder.UseNpgsql(GetConnectionStringByName("PostgreSQL"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
