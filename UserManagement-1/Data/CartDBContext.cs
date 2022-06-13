using Microsoft.EntityFrameworkCore;
using UserManagement_1.Models;

namespace UserManagement_1.Data
{
    public class CartDBContext : DbContext
    {
        public CartDBContext(DbContextOptions<CartDBContext> options)
           : base(options)
        {

        }
        public DbSet<Cart> cart { get; set; }
    }
}
