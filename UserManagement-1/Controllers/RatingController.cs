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
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingController(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IEnumerable<Rating>> GetUsers()
        {
            return await _ratingRepository.Get();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Rating>> GetUsers(int id)
        {
            return await _ratingRepository.Get(id);
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<Rating>> PostUsers([FromBody] Rating rating)
        {
            var newUser = await _ratingRepository.Create(rating);
            return CreatedAtAction(nameof(GetUsers), new { id = newUser }, newUser);
        }

        [HttpPut]
        public async Task<ActionResult> PutUsers(int id, [FromBody] Rating rating)
        {
            if (id != rating.RatingId)
            {
                return BadRequest();
            }
            await _ratingRepository.Update(rating);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userToDelete = await _ratingRepository.Get(id);
            if (userToDelete == null)
            {
                return NotFound();
            }
            await _ratingRepository.Delete(userToDelete.RatingId);
            return NoContent();
        }
    }
}
