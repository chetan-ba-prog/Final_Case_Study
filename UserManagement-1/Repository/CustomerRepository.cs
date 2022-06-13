using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement_1.Data;
using UserManagement_1.Models;

namespace UserManagement_1.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDBContext _con;

        public CustomerRepository(CustomerDBContext con)
        {
            _con = con;
        }
        public async Task<Customer> Create(Customer customer)
        {
            _con.customer.Add(customer);

            await _con.SaveChangesAsync();
            return customer;
        }

        public async Task Delete(int id)
        {
            var userToDelete = await _con.customer.FindAsync(id);
            _con.customer.Remove(userToDelete);
            _con.SaveChanges();
        }

        public async Task<IEnumerable<Customer>> Get()
        {
            return await _con.customer.ToListAsync();
        }

        public async Task<Customer> Get(int id)
        {
            return await _con.customer.FindAsync(id);
        }

        public async Task Update(Customer customer)
        {
            _con.Entry(customer).State = EntityState.Modified;
            await _con.SaveChangesAsync();
        }
    }
}
