using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement_1.Models;
using UserManagement_1.Repository;

namespace UserManagement_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        [HttpGet]
        [Route("GetInvoice")]
        public async Task<IEnumerable<Invoice>> GetUsers()
        {
            return await _invoiceRepository.Get();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetUsers(int id)
        {
            return await _invoiceRepository.Get(id);
        }

        [HttpPost]
        [Route("CreateInvoice")]
        public async Task<ActionResult<Invoice>> PostUsers([FromBody] Invoice invoice)
        {
            var newUser = await _invoiceRepository.Create(invoice);
            return CreatedAtAction(nameof(GetUsers), new { id = newUser }, newUser);
        }

        [HttpPut]
        [Route("UpdateInvoice")]
        public async Task<ActionResult> PutUsers(int id, [FromBody] Invoice invoice)
        {
            if (id != invoice.InvoiceId)
            {
                return BadRequest();
            }
            await _invoiceRepository.Update(invoice);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userToDelete = await _invoiceRepository.Get(id);
            if (userToDelete == null)
            {
                return NotFound();
            }
            await _invoiceRepository.Delete(userToDelete.OrderId);
            return NoContent();
        }
    }
}
