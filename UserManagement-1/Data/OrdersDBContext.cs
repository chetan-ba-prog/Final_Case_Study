using Microsoft.EntityFrameworkCore;
using UserManagement_1.Models;

namespace UserManagement_1.Data
{
    public class OrdersDBContext: DbContext
    {
        public OrdersDBContext(DbContextOptions<OrdersDBContext> options)
           : base(options)
        {

        }
        public DbSet<Orders> orders { get; set; }
    }
}
