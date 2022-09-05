using Microsoft.EntityFrameworkCore;
using ProductApi.Data;

namespace ProductApi.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<State> States { get; set; }
    }
}
