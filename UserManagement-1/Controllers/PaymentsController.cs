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
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsRepository _paymentsRepository;
        private PaymentsDBContext _context;

        public PaymentsController(IPaymentsRepository paymentsRepository, PaymentsDBContext context)
        {
            _paymentsRepository = paymentsRepository;
            _context = context;

        }
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IEnumerable<Payments>> GetUsers()
        {
            return await _paymentsRepository.Get();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Payments>> GetUsers(int id)
        {
            return await _paymentsRepository.Get(id);
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<Payments>> PostUsers([FromBody] Payments payments)
        {
            var newUser = await _paymentsRepository.Create(payments);
            return CreatedAtAction(nameof(GetUsers), new { id = newUser }, newUser);
        }

        [HttpPut]
        public async Task<ActionResult> PutUsers(int id, [FromBody] Payments payments)
        {
            if (id != payments.PaymentId)
            {
                return BadRequest();
            }
            await _paymentsRepository.Update(payments);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userToDelete = await _paymentsRepository.Get(id);
            if (userToDelete == null)
            {
                return NotFound();

            }
            await _paymentsRepository.Delete(userToDelete.ProdId);
            return NoContent();
        }

        [HttpGet]
        [Route("GetPaymentsBySellerId")]
        public async Task<IEnumerable<Payments>> GetPayments(int id)
        {
            return _context.payments.Where(u => u.SellerId == id).ToList();
        }
    }
}
