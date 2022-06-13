using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement_1.Data;
using UserManagement_1.Models;

namespace UserManagement_1.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly OrdersDBContext _con;

        public OrdersRepository(OrdersDBContext con)
        {
            _con = con;
        }
        public async Task<Orders> Create(Orders orders)
        {
            _con.orders.Add(orders);

            await _con.SaveChangesAsync();
            return orders;
        }

        public async Task Delete(int id)
        {
            var userToDelete = await _con.orders.FindAsync(id);
            _con.orders.Remove(userToDelete);
            _con.SaveChanges();
        }

        public async Task<IEnumerable<Orders>> Get()
        {
            return await _con.orders.ToListAsync();
        }

        public async Task<Orders> Get(int id)
        {
            return await _con.orders.FindAsync(id);
        }

        public async Task Update(Orders user)
        {
            _con.Entry(user).State = EntityState.Modified;
            await _con.SaveChangesAsync();
        }
    }
}
