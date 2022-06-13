using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement_1.Models;

namespace UserManagement_1.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(int id);
        Task<Product> Create(Product product);
        Task Update(Product product);
        Task Delete(int id);
    }
}
