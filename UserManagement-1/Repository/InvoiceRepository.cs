using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement_1.Data;
using UserManagement_1.Models;

namespace UserManagement_1.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly InvoiceDBContext _con;

        public InvoiceRepository(InvoiceDBContext con)
        {
            _con = con;
        }
        public async Task<Invoice> Create(Invoice invoice)
        {
            _con.invoice.Add(invoice);

            await _con.SaveChangesAsync();
            return invoice;
        }

        public async Task Delete(int id)
        {
            var userToDelete = await _con.invoice.FindAsync(id);
            _con.invoice.Remove(userToDelete);
            _con.SaveChanges();
        }

        public async Task<IEnumerable<Invoice>> Get()
        {
            return await _con.invoice.ToListAsync();
        }

        public async Task<Invoice> Get(int id)
        {
            return await _con.invoice.FindAsync(id);
        }

        public async Task Update(Invoice invoice)
        {
            _con.Entry(invoice).State = EntityState.Modified;
            await _con.SaveChangesAsync();
        }
    }
}
