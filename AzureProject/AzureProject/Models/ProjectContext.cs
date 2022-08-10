using Microsoft.EntityFrameworkCore;

namespace AzureProject.Models
{
    public class ProjectContext : DbContext
    {

        public ProjectContext()
        {

        }

        public ProjectContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("dbconn"));
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<UserMaster> UserMasters { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<Categories> Categories { get; set; }

    }
}
