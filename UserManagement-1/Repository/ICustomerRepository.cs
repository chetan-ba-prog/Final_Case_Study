using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement_1.Models;

namespace UserManagement_1.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> Get();
        Task<Customer> Get(int id);
        Task<Customer> Create(Customer customer);
        Task Update(Customer customer);
        Task Delete(int id);
    }
}
