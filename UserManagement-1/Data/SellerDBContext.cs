using Microsoft.EntityFrameworkCore;
using UserManagement_1.Models;

namespace UserManagement_1.Data
{
    public class SellerDBContext : DbContext
    {
        public SellerDBContext(DbContextOptions<SellerDBContext> options)
            : base(options)
        {

        }
        public DbSet<Seller> seller { get; set; }

    }

}
