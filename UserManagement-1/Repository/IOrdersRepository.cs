using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement_1.Models;

namespace UserManagement_1.Repository
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Orders>> Get();
        Task<Orders> Get(int id);
        Task<Orders> Create(Orders orders);
        Task Update(Orders orders);
        Task Delete(int id);
    }
}
