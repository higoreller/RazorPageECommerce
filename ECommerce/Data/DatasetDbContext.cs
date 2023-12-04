using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace ECommerce.Data
{
    public class DatasetDbContext : DbContext
    {
        public DbSet<Dataset> Dataset { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string conn = config.GetConnectionString("Conn");

            optionsBuilder.UseSqlServer(conn);
        }
    }
}
