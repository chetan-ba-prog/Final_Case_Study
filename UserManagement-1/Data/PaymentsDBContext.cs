using Microsoft.EntityFrameworkCore;
using UserManagement_1.Models;

namespace UserManagement_1.Data
{
    public class PaymentsDBContext : DbContext
    {
        public PaymentsDBContext(DbContextOptions<PaymentsDBContext> options)
          : base(options)
        {

        }
        public DbSet<Payments> payments { get; set; }
    }
}
