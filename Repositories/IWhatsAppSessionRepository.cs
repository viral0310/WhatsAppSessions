// Repositories/IWhatsAppSessionRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using WhatsAppSessionApi.Models;

namespace WhatsAppSessionApi.Repositories
{
    public interface IWhatsAppSessionRepository
    {
        Task<IEnumerable<WhatsAppSession>> GetAllAsync();
        Task<WhatsAppSession> GetByIdAsync(int id);
        Task AddAsync(WhatsAppSession session);
        Task UpdateAsync(WhatsAppSession session);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
