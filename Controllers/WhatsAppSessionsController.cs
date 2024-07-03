// Controllers/WhatsAppSessionsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsAppSessionApi.Data;
using WhatsAppSessionApi.Models;

namespace WhatsAppSessionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsAppSessionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WhatsAppSessionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WhatsAppSession>>> GetWhatsAppSessions()
        {
            return await _context.WhatsAppSessions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WhatsAppSession>> GetWhatsAppSession(int id)
        {
            var session = await _context.WhatsAppSessions.FindAsync(id);

            if (session == null)
            {
                return NotFound();
            }

            return session;
        }

        [HttpPost]
        public async Task<ActionResult<WhatsAppSession>> PostWhatsAppSession(WhatsAppSession session)
        {
            _context.WhatsAppSessions.Add(session);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWhatsAppSession), new { id = session.Id }, session);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWhatsAppSession(int id, WhatsAppSession session)
        {
            if (id != session.Id)
            {
                return BadRequest();
            }

            _context.Entry(session).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WhatsAppSessionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhatsAppSession(int id)
        {
            var session = await _context.WhatsAppSessions.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }

            _context.WhatsAppSessions.Remove(session);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WhatsAppSessionExists(int id)
        {
            return _context.WhatsAppSessions.Any(e => e.Id == id);
        }
    }
}
