using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement_1.Data;
using UserManagement_1.Models;

namespace UserManagement_1.Repository
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly PaymentsDBContext _con;

        public PaymentsRepository(PaymentsDBContext con)
        {
            _con = con;
        }
        public async Task<Payments> Create(Payments payments)
        {
            _con.payments.Add(payments);

            await _con.SaveChangesAsync();
            return payments;
        }

        public async Task Delete(int id)
        {
            var userToDelete = await _con.payments.FindAsync(id);
            _con.payments.Remove(userToDelete);
            _con.SaveChanges();
        }

        public async Task<IEnumerable<Payments>> Get()
        {
            return await _con.payments.ToListAsync();
        }

        public async Task<Payments> Get(int id)
        {
            return await _con.payments.FindAsync(id);
        }

        public async Task Update(Payments payments)
        {
            _con.Entry(payments).State = EntityState.Modified;
            await _con.SaveChangesAsync();
        }
    }
}
