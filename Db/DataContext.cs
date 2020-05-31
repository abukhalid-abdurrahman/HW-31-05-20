using Microsoft.EntityFrameworkCore;

namespace Solution
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options){ Database.EnsureCreated(); }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Superuser> Superusers { get; set; }
    }
}