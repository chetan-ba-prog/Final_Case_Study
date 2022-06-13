using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement_1.Models;

namespace UserManagement_1.Repository
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> Get();
        Task<Cart> Get(int id);
        Task<Cart> Create(Cart cart);
        Task Update(Cart cart);
        Task Delete(int id);
    }
}
