using BasicApi.NetCore5.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicApi.NetCore5.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
