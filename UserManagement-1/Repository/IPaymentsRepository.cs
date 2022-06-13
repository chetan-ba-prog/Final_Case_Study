using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement_1.Models;

namespace UserManagement_1.Repository
{
    public interface IPaymentsRepository
    {
        Task<IEnumerable<Payments>> Get();
        Task<Payments> Get(int id);
        Task<Payments> Create(Payments payments);
        Task Update(Payments payments);
        Task Delete(int id);
    }
}
