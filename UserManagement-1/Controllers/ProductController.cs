using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement_1.Data;
using UserManagement_1.Models;
using UserManagement_1.Repository;

namespace UserManagement_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private ProductDBContext _context;

        public ProductController(IProductRepository productRepository, ProductDBContext context)
        {
            _productRepository = productRepository;
            _context = context;
        }
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IEnumerable<Product>> GetUsers()
        {
            return await _productRepository.Get();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetUsers(int id)
        {
            return await _productRepository.Get(id);

        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<Product>> PostUsers([FromBody] Product product)
        {
            var newUser = await _productRepository.Create(product);
            return CreatedAtAction(nameof(GetUsers), new { id = newUser }, newUser);
        }

        [HttpPut]
        public async Task<ActionResult> PutUsers(int id, [FromBody] Product product)
        {
            if (id != product.ProdId)
            {
                return BadRequest();
            }
            await _productRepository.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userToDelete = await _productRepository.Get(id);
            if (userToDelete == null)
            {
                return NotFound();
            }
            await _productRepository.Delete(userToDelete.ProdId);
            return NoContent();
        }

        [HttpGet]
        [Route("GetProduct")]
        public async Task<IEnumerable<Product>> GetProduct(int id)
        {
            return _context.product.Where(u => u.SellerId == id).ToList();
        }      

    }
}
