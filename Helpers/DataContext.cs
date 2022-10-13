using Microsoft.EntityFrameworkCore;
using CRMSYSTEMBACK.Entities;

namespace CRMSYSTEMBACK.Helpers
{
    public class DataContext : DbContext
    {

        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("CRMAppCon");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Project { get; set; }
    }
}
