using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private CustomerDBContext _context;

        public CustomerController(ICustomerRepository customerRepository, CustomerDBContext context)
        {
            _customerRepository = customerRepository;
            _context = context;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IEnumerable<Customer>> GetUsers()
        {
            return await _customerRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetUsers(int id)
        {
            return await _customerRepository.Get(id);
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<Customer>> PostUsers([FromBody] Customer customer)
        {
            var newUser = await _customerRepository.Create(customer);
            return CreatedAtAction(nameof(GetUsers), new { id = newUser }, newUser);
        }

        [HttpPut]
        public async Task<ActionResult> PutUsers(int id, [FromBody] Customer customer)
        {
            if (id != customer.CustId)
            {
                return BadRequest();
            }
            await _customerRepository.Update(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userToDelete = await _customerRepository.Get(id);
            if (userToDelete == null)
            {
                return NotFound();

            }
            await _customerRepository.Delete(userToDelete.CustId);
            return NoContent();
        }

       /* [HttpPost("LoginUser")]
        public IActionResult Login(CustomerLogin user)
        {
            var userAvailable = _context.customer.Where(u => u.CustEmail == user.custEmail && u.CustPassword == user.custPassword).FirstOrDefault();
            if (userAvailable != null)
            {
                return Ok("Success");
            }
            return Ok("Failure");
        }*/

        // new 
        [HttpPost("LoginUser")]
        public async Task<ResponseModel> Login(CustomerLogin user)
        {
            ResponseModel responseVM = new();
            try
            {
                var userAvailable = _context.customer.Where(u => u.CustEmail == user.custEmail && u.CustPassword == user.custPassword).FirstOrDefault();

                if (userAvailable == null)
                {
                    responseVM.IsSuccess = true;
                    responseVM.StatusCode = Status.RecordNotFound;
                    responseVM.Message = "RecordNotFound";
                }
                else
                {
                    responseVM.Response = userAvailable;
                    responseVM.IsSuccess = true;
                    responseVM.StatusCode = Status.OK;
                    responseVM.Message = "Sucess";

                }
                return responseVM;
            }
            catch (Exception ex)
            {
                responseVM.IsSuccess = false;
                responseVM.Errors = ex.ToString();
                responseVM.StatusCode = Status.BadRequest;
                responseVM.Message = "Failure";
                return responseVM;
            }
        }
    }
}
