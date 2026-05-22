using celticsTech.DTOs.Request;
using celticsTech.Enums;
using celticsTech.Services;
using Microsoft.AspNetCore.Mvc;

namespace celticsTech.Controllers
{
    [ApiController]
    [Route("api/veterinarians")]
    public class VeterinariansController : ControllerBase
    {
        private readonly VeterinarianService _veterinarianService;

        public VeterinariansController(VeterinarianService veterinarianService)
        {
            _veterinarianService = veterinarianService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VeterinarianRequestDTO dto)
        {
            try
            {
                var veterinarian = await _veterinarianService.CreateAsync(dto);
                return CreatedAtAction(nameof(FindById), new { id = veterinarian.Id }, veterinarian);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var veterinarians = await _veterinarianService.FindAllAsync();
            return Ok(veterinarians);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            try
            {
                var veterinarian = await _veterinarianService.FindByIdAsync(id);
                return Ok(veterinarian);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("search/name")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            var veterinarians = await _veterinarianService.SearchByNameAsync(name);
            return Ok(veterinarians);
        }

        [HttpGet("search/specialty")]
        public async Task<IActionResult> SearchBySpecialty([FromQuery] SpecialtyEnum specialty)
        {
            var veterinarians = await _veterinarianService.SearchBySpecialtyAsync(specialty);
            return Ok(veterinarians);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] VeterinarianRequestDTO dto)
        {
            try
            {
                var veterinarian = await _veterinarianService.UpdateAsync(id, dto);
                return Ok(veterinarian);
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
                await _veterinarianService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}