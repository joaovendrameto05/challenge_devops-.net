using celticsTech.DTOs.Request;
using celticsTech.Enums;
using celticsTech.Services;
using Microsoft.AspNetCore.Mvc;

namespace celticsTech.Controllers
{
    [ApiController]
    [Route("api/pets")]
    public class PetsController : ControllerBase
    {
        private readonly PetService _petService;

        public PetsController(PetService petService)
        {
            _petService = petService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PetRequestDTO dto)
        {
            var pet = await _petService.CreateAsync(dto);
            return CreatedAtAction(nameof(FindById), new { id = pet.Id }, pet);
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var pets = await _petService.FindAllAsync();
            return Ok(pets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            try
            {
                var pet = await _petService.FindByIdAsync(id);
                return Ok(pet);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] string? species,
            [FromQuery] PetSizeEnum? petSize)
        {
            var pets = await _petService.SearchAsync(species, petSize);
            return Ok(pets);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] PetRequestDTO dto)
        {
            try
            {
                var pet = await _petService.UpdateAsync(id, dto);
                return Ok(pet);
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
                await _petService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}