using celticsTech.DTOs.Request;
using celticsTech.Services;
using Microsoft.AspNetCore.Mvc;

namespace celticsTech.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRequestDTO dto)
        {
            try
            {
                var user = await _userService.CreateAsync(dto);
                return CreatedAtAction(nameof(FindById), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var users = await _userService.FindAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            try
            {
                var user = await _userService.FindByIdAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            var users = await _userService.SearchByNameAsync(name);
            return Ok(users);
        }

        [HttpGet("email")]
        public async Task<IActionResult> FindByEmail([FromQuery] string email)
        {
            try
            {
                var user = await _userService.FindByEmailAsync(email);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UserRequestDTO dto)
        {
            try
            {
                var user = await _userService.UpdateAsync(id, dto);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _userService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}