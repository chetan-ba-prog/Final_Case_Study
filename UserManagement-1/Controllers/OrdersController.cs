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
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _ordersRepository;
        private OrdersDBContext _context;

        public OrdersController(IOrdersRepository ordersRepository, OrdersDBContext context)
        {
            _ordersRepository = ordersRepository;
            _context = context;
        }
        [HttpGet]
        [Route("GetOrders")]
        public async Task<IEnumerable<Orders>> GetUsers()
        {
            return await _ordersRepository.Get();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetUsers(int id)
        {
            return await _ordersRepository.Get(id);
        }

        [HttpPost]
        [Route("CreateOrders")]
        public async Task<ActionResult<Orders>> PostUsers([FromBody] Orders orders)
        {
            var newUser = await _ordersRepository.Create(orders);
            return CreatedAtAction(nameof(GetUsers), new { id = newUser }, newUser);
        }

        [HttpPut]
        [Route("UpdateOrders")]
        public async Task<ActionResult> PutUsers(int id, [FromBody] Orders orders)
        {
            if (id != orders.OrderId)
            {
                return BadRequest();
            }
            await _ordersRepository.Update(orders);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userToDelete = await _ordersRepository.Get(id);
            if (userToDelete == null)
            {
                return NotFound();
            }
            await _ordersRepository.Delete(userToDelete.OrderId);
            return NoContent();
        }

        [HttpGet]
        [Route("GetOrdersBySellerId")]
        public async Task<IEnumerable<Orders>> GetOrdersBySeller(int id)
        {
            return _context.orders.Where(u => u.SellerId == id).ToList();
        }

        [HttpGet]
        [Route("GetOrdersByCustomerId")]
        public async Task<IEnumerable<Orders>> GetOrdersByCustomer(int id)
        {
            return _context.orders.Where(u => u.CustId == id).ToList();
        }
    }
}
