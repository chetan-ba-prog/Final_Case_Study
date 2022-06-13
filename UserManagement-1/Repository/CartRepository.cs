using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement_1.Data;
using UserManagement_1.Models;

namespace UserManagement_1.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly CartDBContext _con;

        public CartRepository(CartDBContext con)
        {
            _con = con;
        }
        public async Task<Cart> Create(Cart cart)
        {
            _con.cart.Add(cart);

            await _con.SaveChangesAsync();
            return cart;
        }

        public async Task Delete(int id)
        {
            var userToDelete = await _con.cart.FindAsync(id);
            _con.cart.Remove(userToDelete);
            _con.SaveChanges();
        }

        public async Task<IEnumerable<Cart>> Get()
        {
            return await _con.cart.ToListAsync();
        }

        public async Task<Cart> Get(int id)
        {
            return await _con.cart.FindAsync(id);
        }

        public async Task Update(Cart cart)
        {
            _con.Entry(cart).State = EntityState.Modified;
            await _con.SaveChangesAsync();
        }
    }
}
