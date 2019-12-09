using Microsoft.EntityFrameworkCore;

namespace SimpleApp.Models
{
    public class ProductsContext : DbContext
    {
        private string password;
        public ProductsContext(string password)
        {
            this.password = password;
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Data Source=den1.mssql8.gear.host;Initial Catalog=simpleapp;User ID=simpleapp;Password={password};Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Product());
        }
    }
}
