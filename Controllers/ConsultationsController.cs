using celticsTech.DTOs.Request;
using celticsTech.Services;
using Microsoft.AspNetCore.Mvc;

namespace celticsTech.Controllers
{
    [ApiController]
    [Route("api/consultations")]
    public class ConsultationsController : ControllerBase
    {
        private readonly ConsultationService _consultationService;

        public ConsultationsController(ConsultationService consultationService)
        {
            _consultationService = consultationService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ConsultationRequestDTO dto)
        {
            var consultation = await _consultationService.CreateAsync(dto);
            return CreatedAtAction(nameof(FindById), new { id = consultation.Id }, consultation);
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var consultations = await _consultationService.FindAllAsync();
            return Ok(consultations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            try
            {
                var consultation = await _consultationService.FindByIdAsync(id);
                return Ok(consultation);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] ConsultationRequestDTO dto)
        {
            try
            {
                var consultation = await _consultationService.UpdateAsync(id, dto);
                return Ok(consultation);
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
                await _consultationService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}