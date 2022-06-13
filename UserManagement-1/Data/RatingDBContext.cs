using Microsoft.EntityFrameworkCore;
using UserManagement_1.Models;

namespace UserManagement_1.Data
{
    public class RatingDBContext : DbContext
    {
        public RatingDBContext(DbContextOptions<RatingDBContext> options)
         : base(options)
        {

        }
        public DbSet<Rating> rating { get; set; }
    }
}
