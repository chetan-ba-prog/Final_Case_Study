using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement_1.Data;
using UserManagement_1.Models;

namespace UserManagement_1.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDBContext _con;

        public ProductRepository(ProductDBContext con)
        {
            _con = con;
        }
        public async Task<Product> Create(Product product)
        {
            _con.product.Add(product);

            await _con.SaveChangesAsync();
            return product;
        }

        public async Task Delete(int id)
        {
            var userToDelete = await _con.product.FindAsync(id);
            _con.product.Remove(userToDelete);
            _con.SaveChanges();
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await _con.product.ToListAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await _con.product.FindAsync(id);
        }

        public async Task Update(Product product)
        {
            _con.Entry(product).State = EntityState.Modified;
            await _con.SaveChangesAsync();
        }
    }
}
