using Microsoft.EntityFrameworkCore;
using SimpleApp.Interfaces;
using System.Threading.Tasks;

namespace SimpleApp.Models
{
    public class ProductsContext : DbContext, IProductsContext
    {
        private readonly string url;

        DbSet<Product> IProductsContext.Products { get; set; }

        public ProductsContext(string url) => this.url = url;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(url);

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfiguration(new Product());

        async Task IProductsContext.SaveChangesAsync() => await base.SaveChangesAsync();
    }
}