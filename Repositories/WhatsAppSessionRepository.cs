// Repositories/WhatsAppSessionRepository.cs
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhatsAppSessionApi.Data;
using WhatsAppSessionApi.Models;

namespace WhatsAppSessionApi.Repositories
{
    public class WhatsAppSessionRepository : IWhatsAppSessionRepository
    {
        private readonly AppDbContext _context;

        public WhatsAppSessionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WhatsAppSession>> GetAllAsync()
        {
            return await _context.WhatsAppSessions.ToListAsync();
        }

        public async Task<WhatsAppSession> GetByIdAsync(int id)
        {
            return await _context.WhatsAppSessions.FindAsync(id);
        }

        public async Task AddAsync(WhatsAppSession session)
        {
            _context.WhatsAppSessions.Add(session);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WhatsAppSession session)
        {
            _context.Entry(session).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var session = await _context.WhatsAppSessions.FindAsync(id);
            if (session != null)
            {
                _context.WhatsAppSessions.Remove(session);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.WhatsAppSessions.AnyAsync(e => e.Id == id);
        }
    }
}
