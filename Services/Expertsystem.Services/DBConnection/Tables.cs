using Expertsystem.Models;
using Expertsystem.Services.Models;
using Microsoft.EntityFrameworkCore;


namespace Expertsystem.Services.DBConnection
{
    public partial class PostgresSQL : DbContext
    {
        public DbSet<CompanyModel> Companies { get; set; }
    }
}
