using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement_1.Data;
using UserManagement_1.Models;

namespace UserManagement_1.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly RatingDBContext _con;

        public RatingRepository(RatingDBContext con)
        {
            _con = con;
        }
        public async Task<Rating> Create(Rating rating)
        {
            _con.rating.Add(rating);

            await _con.SaveChangesAsync();
            return rating;
        }

        public async Task Delete(int id)
        {
            var userToDelete = await _con.rating.FindAsync(id);
            _con.rating.Remove(userToDelete);
            _con.SaveChanges();
        }

        public async Task<IEnumerable<Rating>> Get()
        {
            return await _con.rating.ToListAsync();
        }

        public async Task<Rating> Get(int id)
        {
            return await _con.rating.FindAsync(id);
        }

        public async Task Update(Rating rating)
        {
            _con.Entry(rating).State = EntityState.Modified;
            await _con.SaveChangesAsync();
        }
    }
}
