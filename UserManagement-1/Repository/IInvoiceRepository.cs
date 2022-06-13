using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement_1.Models;

namespace UserManagement_1.Repository
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> Get();
        Task<Invoice> Get(int id);
        Task<Invoice> Create(Invoice invoice);
        Task Update(Invoice invoice);
        Task Delete(int id);
    }
}
