// Controllers/WhatsAppSessionsController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhatsAppSessionApi.Models;
using WhatsAppSessionApi.Repositories;

namespace WhatsAppSessionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsAppSessionsController : ControllerBase
    {
        private readonly IWhatsAppSessionRepository _repository;

        public WhatsAppSessionsController(IWhatsAppSessionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WhatsAppSession>>> GetWhatsAppSessions()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WhatsAppSession>> GetWhatsAppSession(int id)
        {
            var session = await _repository.GetByIdAsync(id);

            if (session == null)
            {
                return NotFound();
            }

            return Ok(session);
        }

        [HttpPost]
        public async Task<ActionResult<WhatsAppSession>> PostWhatsAppSession(WhatsAppSession session)
        {
            await _repository.AddAsync(session);
            return CreatedAtAction(nameof(GetWhatsAppSession), new { id = session.Id }, session);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWhatsAppSession(int id, WhatsAppSession session)
        {
            if (id != session.Id)
            {
                return BadRequest();
            }

            if (!await _repository.ExistsAsync(id))
            {
                return NotFound();
            }

            await _repository.UpdateAsync(session);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhatsAppSession(int id)
        {
            if (!await _repository.ExistsAsync(id))
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
