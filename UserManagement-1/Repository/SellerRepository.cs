using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement_1.Data;
using UserManagement_1.Models;

namespace UserManagement_1.Repository
{
    public class SellerRepository : ISellerRepository
    {
        private readonly SellerDBContext _con;

        public SellerRepository(SellerDBContext con)
        {
            _con = con;
        }
        public async Task<Seller> Create(Seller seller)
        {
            _con.seller.Add(seller);

            await _con.SaveChangesAsync();
            return seller;
        }

        public async Task Delete(int id)
        {
            var userToDelete = await _con.seller.FindAsync(id);
            _con.seller.Remove(userToDelete);
            _con.SaveChanges();
        }

        public async Task<IEnumerable<Seller>> Get()
        {
            return await _con.seller.ToListAsync();
        }

        public async Task<Seller> Get(int id)
        {
            return await _con.seller.FindAsync(id);
        }

        public async Task Update(Seller user)
        {
            _con.Entry(user).State = EntityState.Modified;
            await _con.SaveChangesAsync();
        }

    }
}
