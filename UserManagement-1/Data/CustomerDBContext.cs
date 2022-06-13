using Microsoft.EntityFrameworkCore;
using UserManagement_1.Models;

namespace UserManagement_1.Data
{
    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext(DbContextOptions<CustomerDBContext> options)
           : base(options)
        {

        }
        public DbSet<Customer> customer { get; set; }

    }
}
