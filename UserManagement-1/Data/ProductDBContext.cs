using Microsoft.EntityFrameworkCore;
using UserManagement_1.Models;

namespace UserManagement_1.Data
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options)
           : base(options)
        {

        }
        public DbSet<Product> product { get; set; }
    }
}
