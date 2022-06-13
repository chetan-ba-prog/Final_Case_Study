using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement_1.Models;

namespace UserManagement_1.Repository
{
    public interface ISellerRepository
    {
        Task<IEnumerable<Seller>> Get();
        Task<Seller> Get(int id);
        Task<Seller> Create(Seller seller);
        Task Update(Seller seller);
        Task Delete(int id);
    }
}

