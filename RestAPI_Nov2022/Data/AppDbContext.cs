using Microsoft.EntityFrameworkCore;
using RestAPI_Nov2022.Models;

namespace RestAPI_Nov2022.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> op) : base(op) { }

        public DbSet<Order> Orders { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<OrderProducts> OrderProducts { set; get; }
    }
}
