using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private CartDBContext _context;

        public CartController(ICartRepository cartRepository, CartDBContext context)
        {
            _cartRepository = cartRepository;
            _context = context;
        }
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IEnumerable<Cart>> GetUsers()
        {
            return await _cartRepository.Get();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetUsers(int id)
        {
            return await _cartRepository.Get(id);
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<Cart>> PostUsers([FromBody] Cart cart)
        {
            var newUser = await _cartRepository.Create(cart);
            return CreatedAtAction(nameof(GetUsers), new { id = newUser }, newUser);
        }

        [HttpPut]
        public async Task<ActionResult> PutUsers(int id, [FromBody] Cart cart)
        {
            if (id != cart.CartId)
            {
                return BadRequest();
            }
            await _cartRepository.Update(cart);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userToDelete = await _cartRepository.Get(id);
            if (userToDelete == null)
            {
                return NotFound();
            }
            await _cartRepository.Delete(userToDelete.CartId);
            return NoContent();
        }

        [HttpGet]
        [Route("GetCartByCust")]
        public async Task<IEnumerable<Cart>> GetCartByCust(int id)
        {
            return _context.cart.Where(u => u.CustId == id).ToList();
        }

    }
}
