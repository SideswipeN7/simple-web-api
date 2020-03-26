using Microsoft.EntityFrameworkCore;
using SimpleApp.Models;
using System.Threading.Tasks;

namespace SimpleApp.Interfaces
{
    public interface IProductsContext
    {
        DbSet<Product> Products { get; set; }

        Task SaveChangesAsync();
    }
}