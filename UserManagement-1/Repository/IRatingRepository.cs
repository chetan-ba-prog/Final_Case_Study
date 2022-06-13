using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement_1.Models;

namespace UserManagement_1.Repository
{
    public interface IRatingRepository
    {
        Task<IEnumerable<Rating>> Get();
        Task<Rating> Get(int id);
        Task<Rating> Create(Rating rating);
        Task Update(Rating rating);
        Task Delete(int id);
    }
}
