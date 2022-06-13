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
    public class SellerController : ControllerBase
    {
        private readonly ISellerRepository _sellerRepository;
        private SellerDBContext _context;

        public SellerController(ISellerRepository sellerRepository, SellerDBContext context)
        {
            _sellerRepository = sellerRepository;
            _context = context;
        }
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IEnumerable<Seller>> GetUsers()
        {
            return await _sellerRepository.Get();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Seller>> GetUsers(int id)
        {
            return await _sellerRepository.Get(id);

        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<Seller>> PostUsers([FromBody] Seller seller)
        {
            var newUser = await _sellerRepository.Create(seller);
            return CreatedAtAction(nameof(GetUsers), new { id = newUser }, newUser);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<ActionResult> PutUsers(int id, [FromBody] Seller seller)
        {
            if (id != seller.SellerId)
            {
                return BadRequest();
            }
            await _sellerRepository.Update(seller);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userToDelete = await _sellerRepository.Get(id);
            if (userToDelete == null)
            {
                return NotFound();

            }
            await _sellerRepository.Delete(userToDelete.SellerId);
            return NoContent();
        }

        //[HttpPost("LoginUser")]
        //public IActionResult Login(SellerLogin user)
        //{
        //    ResponseModel responseModel = new ResponseModel();  
        //    var userAvailable = _context.seller.Where(u => u.SellerEmail == user.sellerEmail && u.SellerPassword == user.sellerPassword).FirstOrDefault();
        //    if (userAvailable != null)
        //    {
        //        responseModel.IsSuccess = true;
        //        responseModel.Response = userAvailable;
        //        return responseModel;

        //    }
        //    return Ok("Failure");
        //}


        // new 
        [HttpPost("LoginUser")]
        public async Task<ResponseModel> Login(SellerLogin user)
        {
            ResponseModel responseVM = new();
            try
            {
                var userAvailable = _context.seller.Where(u => u.SellerEmail == user.sellerEmail && u.SellerPassword == user.sellerPassword).FirstOrDefault();

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
