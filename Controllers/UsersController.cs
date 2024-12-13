using CrudApi.Data.Services;
using CrudApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _service;
        public UsersController(IUsersService service )
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDisplayDto>>> GetUsers()
        {
            var users = await _service.GetAll();
            return Ok(users);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDisplayDto>> GetUser(int id)
        {
            var user = await _service.GetById(id);
            if (user == null) 
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDto userDto)
        {
            var user = await _service.Update(id, userDto);
            if (user == null) 
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser(UserDto userDto)
        {
            var user = await _service.Add(userDto);

            return CreatedAtAction("GetUser", new {id=user.Id}, userDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _service.Delete(id);

            return NoContent();
        }
    }
}
