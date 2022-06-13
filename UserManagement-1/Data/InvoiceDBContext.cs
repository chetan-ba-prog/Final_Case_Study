using Microsoft.EntityFrameworkCore;
using UserManagement_1.Models;

namespace UserManagement_1.Data
{
    public class InvoiceDBContext: DbContext
    {
        public InvoiceDBContext(DbContextOptions<InvoiceDBContext> options)
          : base(options)
        {

        }
        public DbSet<Invoice> invoice { get; set; }
    }
}
